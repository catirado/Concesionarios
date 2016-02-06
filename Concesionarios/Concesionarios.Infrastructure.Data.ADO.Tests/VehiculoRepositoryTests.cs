using Concesionarios.Domain;
using Concesionarios.Infrastructure.Data.ADO.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Concesionarios.Infrastructure.Data.ADO.Tests
{
    [TestClass]
    public class VehiculoRepositoryTests
    {
        private TransactionScope scope;
        private VehiculoRepository repository;

        public VehiculoRepositoryTests()
        {
            repository = new VehiculoRepository(new ADODBConfiguration(@"Data Source=CPU1410000312\NAVDEMO;Initial Catalog=Concesionario;Integrated Security=SSPI"));
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
            var vehiculo = new Vehiculo("Opel", "Astra", 200);
            repository.Add(vehiculo);
            Assert.AreNotEqual(0, vehiculo.Id);
        }

        [TestMethod]
        public void VehiculoRepositoryAddVehiculoInsertIt()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 200);
            repository.Add(vehiculo);

            var recoverVehiculo = repository.Get(vehiculo.Id);
            Assert.IsNotNull(recoverVehiculo);
        }

        [TestMethod]
        public void VehiculoRepositoryRemoveClientThatNotExistsDoNothing()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 200);
            repository.Remove(vehiculo);
        }

        [TestMethod]
        public void VehiculoRepositoryRemoveVehiculoDeleteFromDatabase()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 200);
            repository.Add(vehiculo);

            var recoverVehiculo = repository.Get(vehiculo.Id);
            Assert.IsNotNull(recoverVehiculo);

            repository.Remove(recoverVehiculo);

            recoverVehiculo = repository.Get(vehiculo.Id);
            Assert.IsNull(recoverVehiculo);
        }

        [TestMethod]
        public void VehiculoRepositoryGetOfNonExistsReturnNull()
        {
            var vehiculo = repository.Get(0);
            Assert.IsNull(vehiculo);
        }

        [TestMethod]
        public void VehiculoRepositoryGetReturnItem()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 200);
            repository.Add(vehiculo);

            var recoverVehiculo = repository.Get(vehiculo.Id);
            Assert.IsNotNull(recoverVehiculo);
            Assert.AreEqual(vehiculo.Marca, recoverVehiculo.Marca);
            Assert.AreEqual(vehiculo.Modelo, recoverVehiculo.Modelo);
            Assert.AreEqual(vehiculo.Potencia, recoverVehiculo.Potencia);
        }

        [TestMethod]
        public void VehiculoRepositoryGetAllReturnAllItems()
        {
            var vehiculo1 = new Vehiculo("Opel", "Astra", 200);
            var vehiculo2 = new Vehiculo("Opel", "Vectra", 250);
            var vehiculo3 = new Vehiculo("Renault", "Megane", 200);

            repository.Add(vehiculo1);
            repository.Add(vehiculo2);
            repository.Add(vehiculo3);

            var items = repository.GetAll();
            
            Assert.IsNotNull(items);
            Assert.AreEqual(3, items.Count());
        }

        [TestMethod]
        public void VehiculoRepositoryUpdateVehiculoUpdatesData()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 200);
            repository.Add(vehiculo);

            vehiculo.ChangePotencia(250);

            repository.Update(vehiculo);

            var recoverClient = repository.Get(vehiculo.Id);

            Assert.IsNotNull(recoverClient);
            Assert.AreEqual(250, vehiculo.Potencia);
        }
    }
}
