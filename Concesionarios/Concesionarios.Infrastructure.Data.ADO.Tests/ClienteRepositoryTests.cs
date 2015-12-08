using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Concesionarios.Infrastructure.Data.ADO.Repositories;
using Concesionarios.Domain;

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
            var cliente = new Cliente("Carlos", "Tirado", "941444444", true);
            repository.Add(cliente);
            Assert.AreNotEqual(0, cliente.Id);
        }

        [TestMethod]
        public void CustomerRepositoryAddClientInsertIt()
        {
            var cliente = new Cliente("Carlos", "Tirado", "941444444", true);
            repository.Add(cliente);

            var recoverClient = repository.Get(cliente.Id);
            Assert.IsNotNull(recoverClient);
        }




    }
}
