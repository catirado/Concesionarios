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
    public class PresupuestoRepositoryTests
    {
        private TransactionScope scope;
        private PresupuestoRepository repository;
        private EFUnitOfWorkFactory uowFactory;
        private ClienteRepository clienteRepository;
        private VehiculoRepository vehiculoRepository;
        private Cliente cliente, cliente2;
        private Vehiculo vehiculo, vehiculo2;

        public PresupuestoRepositoryTests()
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();
            uowFactory = new EFUnitOfWorkFactory(System.Data.IsolationLevel.ReadCommitted);
            repository = new PresupuestoRepository(ambientDbContextLocator);
            clienteRepository = new ClienteRepository(ambientDbContextLocator);
            vehiculoRepository = new VehiculoRepository(ambientDbContextLocator); 
            cliente = new Cliente("Carlos", "Tirado", "941", true);
            vehiculo = new Vehiculo("Opel", "Astra", 200);
            cliente2 = new Cliente("Juan", "Pérez", "941", false);
            vehiculo2 = new Vehiculo("Reanult", "Megane", 210);
        }

        private Presupuesto GetPrespuesto()
        {
            var prespuesto = new Presupuesto(cliente, vehiculo, 1500, Presupuesto.PresupuestoEstado.Aceptado);
            return prespuesto;
        }

        [TestInitialize]
        public void Initialize()
        {
            this.scope = new TransactionScope(TransactionScopeOption.Required,
                                                new TransactionOptions
                                                {
                                                    IsolationLevel = IsolationLevel.ReadUncommitted
                                                });

            using (var uow = uowFactory.Create())
            {
                clienteRepository.Add(cliente);
                vehiculoRepository.Add(vehiculo);
                clienteRepository.Add(cliente2);
                vehiculoRepository.Add(vehiculo2);
                uow.Commit();
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.scope.Dispose();
        }


        [TestMethod]
        public void PresupuestoRepositoryAddPresupuestoReturnsId()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto = GetPrespuesto();
                repository.Add(presupuesto);
                uow.Commit();
                Assert.AreNotEqual(0, presupuesto.Id);
            }
        }

        //TODO: exceptions de si estan vacios o no existen en la BD

        [TestMethod]
        public void PresupuestoRepositoryAddPresupuestoInsertIt()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto = GetPrespuesto();

                repository.Add(presupuesto);
                uow.Commit();

                var recoverPresupuesto = repository.Get(presupuesto.Id);
                Assert.IsNotNull(recoverPresupuesto);
                Assert.IsNotNull(recoverPresupuesto.Cliente);
                Assert.IsNotNull(recoverPresupuesto.Vehiculo);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PresupuestoRepositoryRemovePresupuestoThatNotExistsThrowsException()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto = GetPrespuesto();
                repository.Remove(presupuesto);
            }
        }

        //TODO: remove dont remove the others

        [TestMethod]
        public void PresupuestoRepositoryPresupuestoClientDeleteFromDatabase()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto = GetPrespuesto();
                repository.Add(presupuesto);

                var recoverPresupuesto = repository.Get(presupuesto.Id);
                Assert.IsNotNull(recoverPresupuesto);

                repository.Remove(recoverPresupuesto);
                uow.Commit();

                recoverPresupuesto = repository.Get(presupuesto.Id);
                Assert.IsNull(recoverPresupuesto);
            }
        }

        [TestMethod]
        public void PresupuestoRepositoryGetOfNonExistsReturnNull()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto = repository.Get(0);
                Assert.IsNull(presupuesto);
            }
        }

        [TestMethod]
        public void PresupuestoRepositoryGetReturnItem()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto = GetPrespuesto();
                repository.Add(presupuesto);
                uow.Commit();

                var recoverPresupuesto = repository.Get(presupuesto.Id);
                Assert.IsNotNull(recoverPresupuesto);
                Assert.IsNotNull(recoverPresupuesto.Vehiculo);
                Assert.IsNotNull(recoverPresupuesto.Cliente);

                Assert.AreEqual(presupuesto.Estado, recoverPresupuesto.Estado);
                Assert.AreEqual(presupuesto.Importe, recoverPresupuesto.Importe);

                Assert.AreEqual(cliente.Nombre, recoverPresupuesto.Cliente.Nombre);
                Assert.AreEqual(cliente.Apellidos, recoverPresupuesto.Cliente.Apellidos);
                Assert.AreEqual(cliente.Telefono, recoverPresupuesto.Cliente.Telefono);
                Assert.AreEqual(cliente.Vip, recoverPresupuesto.Cliente.Vip);

                Assert.AreEqual(vehiculo.Marca, recoverPresupuesto.Vehiculo.Marca);
                Assert.AreEqual(vehiculo.Modelo, recoverPresupuesto.Vehiculo.Modelo);
                Assert.AreEqual(vehiculo.Potencia, recoverPresupuesto.Vehiculo.Potencia);
            }
        }

        [TestMethod]
        public void CustomerRepositoryUpdateClientUpdatesData()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto = GetPrespuesto();
                repository.Add(presupuesto);

                presupuesto.CambiarImporteNegociado(2000);

                repository.Update(presupuesto);
                uow.Commit();

                var recoverPresupuesto = repository.Get(presupuesto.Id);

                Assert.IsNotNull(recoverPresupuesto);
                Assert.AreEqual(2000, recoverPresupuesto.Importe);
            }
        }

        [TestMethod]
        public void PresupuestoRepositoryListadoByVehiculo()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto1 = new Presupuesto(cliente, vehiculo, 2000);
                var presupuesto2 = new Presupuesto(cliente2, vehiculo, 2000);
                var presupuesto3 = new Presupuesto(cliente, vehiculo2, 2000);

                repository.Add(presupuesto1);
                repository.Add(presupuesto2);
                repository.Add(presupuesto3);
                uow.Commit();

                var items = repository.FindAllPresupuestosByVehiculo(vehiculo.Id);

                Assert.IsNotNull(items);
                Assert.AreEqual(2, items.Count());
                foreach (var item in items)
                {
                    Assert.AreEqual(item.Vehiculo.Id, vehiculo.Id);
                }
            }
        }

        [TestMethod]
        public void PresupuestoRepositoryListadoByCliente()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto1 = new Presupuesto(cliente, vehiculo, 2000);
                var presupuesto2 = new Presupuesto(cliente2, vehiculo, 2000);
                var presupuesto3 = new Presupuesto(cliente, vehiculo2, 2000);

                repository.Add(presupuesto1);
                repository.Add(presupuesto2);
                repository.Add(presupuesto3);
                uow.Commit();

                var items = repository.FindAllPresupuestosByCliente(cliente.Id);

                Assert.IsNotNull(items);
                Assert.AreEqual(2, items.Count());
                foreach (var item in items)
                {
                    Assert.AreEqual(item.Cliente.Id, cliente.Id);
                }
            }
        }

        [TestMethod]
        public void PresupuestoRepositoryGetAll()
        {
            using (var uow = uowFactory.Create())
            {
                var presupuesto1 = new Presupuesto(cliente, vehiculo, 2000);
                var presupuesto2 = new Presupuesto(cliente2, vehiculo, 2000);
                var presupuesto3 = new Presupuesto(cliente, vehiculo2, 2000);

                repository.Add(presupuesto1);
                repository.Add(presupuesto2);
                repository.Add(presupuesto3);
                uow.Commit();

                var items = repository.GetAll();

                Assert.IsNotNull(items);
                Assert.AreEqual(3, items.Count());
            }
        }

    }
}
