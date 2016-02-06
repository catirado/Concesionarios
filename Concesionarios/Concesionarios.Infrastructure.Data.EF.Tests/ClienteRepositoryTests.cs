using Concesionarios.Domain;
using Concesionarios.Infrastructure.Data.EF.Helpers.Implementations;
using Concesionarios.Infrastructure.Data.EF.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Concesionarios.Infrastructure.Data.EF.Tests
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        private TransactionScope scope;
        private ClienteRepository repository;
        private EFUnitOfWorkFactory uowFactory;

        public ClienteRepositoryTests()
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();
            uowFactory = new EFUnitOfWorkFactory(System.Data.IsolationLevel.ReadCommitted);
            repository = new ClienteRepository(ambientDbContextLocator);
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
            using (var uow = uowFactory.Create())
            {
                var cliente = new Cliente("Carlos", "Tirado", "941444444", true);
                repository.Add(cliente);
                uow.Commit();
                Assert.AreNotEqual(0, cliente.Id);
            }
        }

        [TestMethod]
        public void CustomerRepositoryAddClientInsertIt()
        {
            using (var uow = uowFactory.Create())
            {
                var cliente = new Cliente("Carlos", "Tirado", "941444444", true);
                repository.Add(cliente);

                var recoverClient = repository.Get(cliente.Id);
                uow.Commit();
                Assert.IsNotNull(recoverClient);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CustomerRepositoryRemoveClientThatNotExistsThrowsException()
        {
            using (var uow = uowFactory.Create())
            {
                var cliente = new Cliente("Carlos", "Tirado", "934344", true);
                repository.Remove(cliente);
                uow.Commit();
            }
        }

        [TestMethod]
        public void CustomerRepositoryRemoveClientDeleteFromDatabase()
        {
            using (var uow = uowFactory.Create())
            {
                var cliente = new Cliente("Carlos", "Tirado", "941444444", true);
                repository.Add(cliente);

                var recoverClient = repository.Get(cliente.Id);
                Assert.IsNotNull(recoverClient);

                repository.Remove(recoverClient);

                recoverClient = repository.Get(cliente.Id);
                
                uow.Commit();
                Assert.IsNull(recoverClient);
            }
        }

        [TestMethod]
        public void CustomerRepositoryGetOfNonExistsReturnNull()
        {
            using (var uow = uowFactory.Create())
            {
                var cliente = repository.Get(0);
                Assert.IsNull(cliente);
            }
        }

        [TestMethod]
        public void CustomerRepositoryGetReturnItem()
        {
            using (var uow = uowFactory.Create())
            {
                var cliente = new Cliente("Carlos", "Tirado", "941444444", true);
                repository.Add(cliente);
                uow.Commit();

                var recoverClient = repository.Get(cliente.Id);
                Assert.IsNotNull(recoverClient);
                Assert.AreEqual(cliente.Nombre, recoverClient.Nombre);
                Assert.AreEqual(cliente.Apellidos, recoverClient.Apellidos);
                Assert.AreEqual(cliente.Telefono, recoverClient.Telefono);
                Assert.AreEqual(cliente.Vip, recoverClient.Vip);
            }
        }

        [TestMethod]
        public void CustomerRepositoryGetAllReturnAllItems()
        {
            using (var uow = uowFactory.Create())
            {
                var cliente1 = new Cliente("Carlos", "Tirado", "941444444", true);
                var cliente2 = new Cliente("Jose", "Juan", "941444444", false);
                var cliente3 = new Cliente("María", "DB", "941444444", false);

                repository.Add(cliente1);
                repository.Add(cliente2);
                repository.Add(cliente3);
                uow.Commit();

                var items = repository.GetAll();

                Assert.IsNotNull(items);
                Assert.AreEqual(3, items.Count());
            }
        }

        [TestMethod]
        public void CustomerRepositoryUpdateClientUpdatesData()
        {
            using (var uow = uowFactory.Create())
            {
                var cliente = new Cliente("Carlos", "Tirado", "941444444", true);
                repository.Add(cliente);

                cliente.ChangeNombre("Jose", "Tirado");

                repository.Update(cliente);
                uow.Commit();

                var recoverClient = repository.Get(cliente.Id);

                Assert.IsNotNull(recoverClient);
                Assert.AreEqual("Jose", cliente.Nombre);
            }
        }

    }
}
