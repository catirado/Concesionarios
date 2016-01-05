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
        private Presupuesto GetPresupuesto()
        {
            return new Presupuesto(
                1,
                new Cliente(1, "carlos", "tirado", "", true), 
                new Vehiculo(1, "Opel", "Astra", 200), 
                100);
        }

        [TestMethod]
        public void CreateNewPresupuestoHaveEstadoAbiertoByDefault()
        {
            var presupuesto = GetPresupuesto();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Abierto);
        }

        [TestMethod]
        public void AceptarPresupuestoSetEstadoToAceptado()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Aceptar();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Aceptado);
        }

        [TestMethod]
        public void CerrarPresupuestoSetEstadoToCerrado()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Cerrar();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Cerrado);
        }

        [TestMethod]
        public void ReabrirPresupuestoSetEstadoToAbierto()
        {
            var presupuesto = GetPresupuesto();
            presupuesto.Cerrar();
            presupuesto.Reabrir();
            Assert.AreEqual(presupuesto.Estado, Concesionarios.Domain.Presupuesto.PresupuestoEstado.Abierto);
        }
    }
}
