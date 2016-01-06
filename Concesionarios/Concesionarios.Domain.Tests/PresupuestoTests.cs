using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Domain.Tests
{
    [TestClass]
    public class PresupuestoTests
    {
        private Vehiculo GetVehiculo()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 200);
            vehiculo.ChangeCurrentIdentity(1);
            return vehiculo;
        }

        private Cliente GetCliente()
        {
            var cliente = new Cliente("carlos", "tirado", "", true);
            cliente.ChangeCurrentIdentity(1);
            return cliente;
        }

        private Presupuesto GetPresupuesto()
        {
            var presupuesto = new Presupuesto(GetCliente(), GetVehiculo(), 100);
            presupuesto.ChangeCurrentIdentity(1);
            return presupuesto;
        }

        [TestMethod]
        public void CreateValidPresupuesto()
        {
            var presupuesto = GetPresupuesto();
            Assert.AreEqual(presupuesto.Id, 1);
            Assert.IsNotNull(presupuesto.Cliente);
            Assert.AreEqual(presupuesto.Cliente.Id, 1);
            Assert.AreEqual(presupuesto.Cliente.Nombre, "carlos");
            Assert.AreEqual(presupuesto.Cliente.Apellidos, "tirado");
            Assert.AreEqual(presupuesto.Cliente.Telefono, "");
            Assert.AreEqual(presupuesto.Cliente.Vip, true);
            Assert.IsNotNull(presupuesto.Vehiculo);
            Assert.AreEqual(presupuesto.Vehiculo.Id, 1);
            Assert.AreEqual(presupuesto.Vehiculo.Marca, "Opel");
            Assert.AreEqual(presupuesto.Vehiculo.Modelo, "Astra");
            Assert.AreEqual(presupuesto.Vehiculo.Potencia, 200);
            Assert.AreEqual(presupuesto.Importe, 100);
        }

        [TestMethod]
        public void CreateNewPresupuestoHaveEstadoAbiertoByDefault()
        {
            var presupuesto = GetPresupuesto();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Abierto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAPresupuestoWithNullCliente()
        {
            var presupuesto = new Presupuesto(
                null,
                GetVehiculo(), 
                100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAPresupuestoWithNullVehiculo()
        {
            var presupuesto = new Presupuesto(
                GetCliente(), 
                null,
                100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateAPresupuestoWithTransientCliente()
        {
            var presupuesto = new Presupuesto(
                new Cliente("carlos", "tirado", "", true),
                GetVehiculo(),
                100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateAPresupuestoWithTransientVehiculo()
        {
            var presupuesto = new Presupuesto(
                GetCliente(),
                new Vehiculo("Opel", "Astra", 200),
                100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateAPresupuestoWithImporteEqualToZero()
        {
            var presupuesto = new Presupuesto(
                GetCliente(),
                GetVehiculo(),
                0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateAPresupuestoWithImporteLessThanZero()
        {
            var presupuesto = new Presupuesto(
                GetCliente(),
                GetVehiculo(),
                -100);
        }

        [TestMethod]
        public void CambiarImporteNegociadoModifyImporte()
        {
            decimal importe = 3000;
            var presupuesto = GetPresupuesto();
            presupuesto.CambiarImporteNegociado(importe);
            Assert.AreEqual(presupuesto.Importe, importe);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCambiarImporteNegociadoWithImporteLessThanZero()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.CambiarImporteNegociado(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCambiarImporteNegociadoWithImporteEqualToZero()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.CambiarImporteNegociado(0);
        }

        [TestMethod]
        public void AceptarPresupuestoSetEstadoToAceptado()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Aceptar();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Aceptado);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotAceptarPresupuestoIfEstadoIsCerrado()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Cerrar();
            presupuesto.Aceptar();
        }

        [TestMethod]
        public void CerrarPresupuestoSetEstadoToCerrado()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Cerrar();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Cerrado);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotCerrarPresupuestoIfEstadoIsCerrado()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Cerrar();
            presupuesto.Cerrar();
        }

        [TestMethod]
        public void ReabrirPresupuestoSetEstadoToAbierto()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Cerrar();
            presupuesto.Reabrir();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Abierto);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotReabrirPresupuestoIfEstadoIsAbierto()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Reabrir();
        }
    }
}
