using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Concesionarios.Infrastructure.Data.ADO.Repositories;
using Concesionarios.Domain;
using System.Linq;

namespace Concesionarios.Infrastructure.Data.ADO.Tests
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        private TransactionScope scope;
        private ClienteRepository repository;

        public ClienteRepositoryTests()
        {
            repository = new ClienteRepository(new ADODBConfiguration(@"Data Source=CPU1410000312\NAVDEMO;Initial Catalog=Concesionario;Integrated Security=SSPI"));
        }

        [TestInitialize]
        public void Initialize()
        {
            this.scope = new TransactionScope(TransactionScopeOption.Required, 
                                                new TransactionOptions
                                                {
                                                    IsolationLevel = IsolationLevel.ReadUncommitted
                                                });
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            this.scope.Dispose();
        }

        [TestMethod]
        public void CustomerRepositoryAddClientReturnsId()
        {
            var cliente = new Cliente(1, "Carlos", "Tirado", "941444444", true);
            repository.Add(cliente);
            Assert.AreNotEqual(0, cliente.Id);
        }

        [TestMethod]
        public void CustomerRepositoryAddClientInsertIt()
        {
            var cliente = new Cliente(1, "Carlos", "Tirado", "941444444", true);
            repository.Add(cliente);

            var recoverClient = repository.Get(cliente.Id);
            Assert.IsNotNull(recoverClient);
        }

        [TestMethod]
        public void CustomerRepositoryRemoveClientThatNotExistsDoNothing()
        {
            var cliente = new Cliente(0, "", "", "", true);
            repository.Remove(cliente);
        }

        [TestMethod]
        public void CustomerRepositoryRemoveClientDeleteFromDatabase()
        {
            var cliente = new Cliente(1, "Carlos", "Tirado", "941444444", true);
            repository.Add(cliente);

            var recoverClient = repository.Get(cliente.Id);
            Assert.IsNotNull(recoverClient);

            repository.Remove(recoverClient);

            recoverClient = repository.Get(cliente.Id);
            Assert.IsNull(recoverClient);
        }

        [TestMethod]
        public void CustomerRepositoryGetOfNonExistsReturnNull()
        {
            var cliente = repository.Get(0);
            Assert.IsNull(cliente);
        }

        [TestMethod]
        public void CustomerRepositoryGetReturnItem()
        {
            var cliente = new Cliente(1, "Carlos", "Tirado", "941444444", true);
            repository.Add(cliente);

            var recoverClient = repository.Get(cliente.Id);
            Assert.IsNotNull(recoverClient);
            Assert.AreEqual(cliente.Nombre, recoverClient.Nombre);
            Assert.AreEqual(cliente.Apellidos, recoverClient.Apellidos);
            Assert.AreEqual(cliente.Telefono, recoverClient.Telefono);
            Assert.AreEqual(cliente.Vip, recoverClient.Vip);
        }

        [TestMethod]
        public void CustomerRepositoryGetAllReturnAllItems()
        {
            var cliente1 = new Cliente(1, "Carlos", "Tirado", "941444444", true);
            var cliente2 = new Cliente(2, "Jose", "Juan", "941444444", false);
            var cliente3 = new Cliente(3, "María", "DB", "941444444", false);

            repository.Add(cliente1);
            repository.Add(cliente2);
            repository.Add(cliente3);

            var items = repository.GetAll();
            
            Assert.IsNotNull(items);
            Assert.AreEqual(3, items.Count());
        }

        [TestMethod]
        public void CustomerRepositoryUpdateClientUpdatesData()
        {
            var cliente = new Cliente(1, "Carlos", "Tirado", "941444444", true);
            repository.Add(cliente);

            cliente.ChangeName("Jose", "Tirado");

            repository.Update(cliente);

            var recoverClient = repository.Get(cliente.Id);

            Assert.IsNotNull(recoverClient);
            Assert.AreEqual("Jose", cliente.Nombre);
        }

    }
}
