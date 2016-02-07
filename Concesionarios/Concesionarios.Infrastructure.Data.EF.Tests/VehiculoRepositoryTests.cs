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
    public class VehiculoRepositoryTests
    {
        private TransactionScope scope;
        private VehiculoRepository repository;
        private EFUnitOfWorkFactory uowFactory;

        public VehiculoRepositoryTests()
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();
            uowFactory = new EFUnitOfWorkFactory(System.Data.IsolationLevel.ReadCommitted);
            repository = new VehiculoRepository(ambientDbContextLocator);
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
        public void VehiculoRepositoryAddVehiculoReturnsId()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo = new Vehiculo("Opel", "Astra", 200);
                repository.Add(vehiculo);
                uow.Commit();
                Assert.AreNotEqual(0, vehiculo.Id);
            }
        }

        [TestMethod]
        public void VehiculoRepositoryAddVehiculoInsertIt()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo = new Vehiculo("Opel", "Astra", 200);
                repository.Add(vehiculo);

                var recoverVehiculo = repository.Get(vehiculo.Id);
                uow.Commit();
                Assert.IsNotNull(recoverVehiculo);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void VehiculoRepositoryRemoveClientThatNotExistsThrowsException()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo = new Vehiculo("Opel", "Astra", 200);
                repository.Remove(vehiculo);
                uow.Commit();
            }
        }

        [TestMethod]
        public void VehiculoRepositoryRemoveVehiculoDeleteFromDatabase()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo = new Vehiculo("Opel", "Astra", 200);
                repository.Add(vehiculo);

                var recoverVehiculo = repository.Get(vehiculo.Id);
                Assert.IsNotNull(recoverVehiculo);

                repository.Remove(recoverVehiculo);

                recoverVehiculo = repository.Get(vehiculo.Id);
                uow.Commit();
                Assert.IsNull(recoverVehiculo);
            }
        }

        [TestMethod]
        public void VehiculoRepositoryGetOfNonExistsReturnNull()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo = repository.Get(0);
                Assert.IsNull(vehiculo);
            }
        }

        [TestMethod]
        public void VehiculoRepositoryGetReturnItem()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo = new Vehiculo("Opel", "Astra", 200);
                repository.Add(vehiculo);
                uow.Commit();

                var recoverVehiculo = repository.Get(vehiculo.Id);
                Assert.IsNotNull(recoverVehiculo);
                Assert.AreEqual(vehiculo.Marca, recoverVehiculo.Marca);
                Assert.AreEqual(vehiculo.Modelo, recoverVehiculo.Modelo);
                Assert.AreEqual(vehiculo.Potencia, recoverVehiculo.Potencia);
            }
        }

        [TestMethod]
        public void VehiculoRepositoryGetAllReturnAllItems()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo1 = new Vehiculo("Opel", "Astra", 200);
                var vehiculo2 = new Vehiculo("Opel", "Vectra", 250);
                var vehiculo3 = new Vehiculo("Renault", "Megane", 200);

                repository.Add(vehiculo1);
                repository.Add(vehiculo2);
                repository.Add(vehiculo3);
                uow.Commit();

                var items = repository.GetAll();

                Assert.IsNotNull(items);
                Assert.AreEqual(3, items.Count());
            }
        }

        [TestMethod]
        public void VehiculoRepositoryUpdateVehiculoUpdatesData()
        {
            using (var uow = uowFactory.Create())
            {
                var vehiculo = new Vehiculo("Opel", "Astra", 200);
                repository.Add(vehiculo);

                vehiculo.ChangePotencia(250);

                repository.Update(vehiculo);
                uow.Commit();

                var recoverVehiculo = repository.Get(vehiculo.Id);

                Assert.IsNotNull(recoverVehiculo);
                Assert.AreEqual(250, recoverVehiculo.Potencia);
            }
        }

    }
}
