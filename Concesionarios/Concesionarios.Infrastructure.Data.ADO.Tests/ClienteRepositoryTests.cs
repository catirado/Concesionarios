using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace Concesionarios.Infrastructure.Data.ADO.Tests
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        private TransactionScope scope;

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
        public void TestMethod1()
        {

        }
    }
}
