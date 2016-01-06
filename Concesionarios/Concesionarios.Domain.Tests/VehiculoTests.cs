using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Domain.Tests
{
    [TestClass]
    public class VehiculoTests
    {
        [TestMethod]
        public void CreateValidVehiculo()
        {
            string marca = "Opel";
            string modelo = "Astra";
            int potencia = 220;

            var vehiculo = new Vehiculo(marca, modelo, potencia);
            Assert.AreEqual(vehiculo.Id, 0);
            Assert.AreEqual(vehiculo.Marca, marca);
            Assert.AreEqual(vehiculo.Modelo, modelo);
            Assert.AreEqual(vehiculo.Potencia, potencia);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAVehiculoWithEmptyMarca()
        {
            var vehiculo = new Vehiculo(String.Empty, "Astra", 220);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAVehiculoWithNullMarca()
        {
            var vehiculo = new Vehiculo(null, "Astra", 220);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAVehiculoWithEmptyModelo()
        {
            var vehiculo = new Vehiculo("Opel", String.Empty, 220);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAVehiculoWithNullModelo()
        {
            var vehiculo = new Vehiculo("Opel", null, 220);
        }

        [TestMethod]
        public void ChangeMarcaModifyMarca()
        {
            string marca = "Renault";
            var vehiculo = new Vehiculo("Opel", "Astra", 220);
            vehiculo.ChangeMarca(marca);
            Assert.AreEqual(vehiculo.Marca, marca);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeMarcaWithEmptyMarca()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 220);
            vehiculo.ChangeMarca(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeMarcaWithNullMarca()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 220);
            vehiculo.ChangeMarca(null);
        }

        [TestMethod]
        public void ChangeMarcaModifyModelo()
        {
            string modelo = "Vectra";
            var vehiculo = new Vehiculo("Opel", "Astra", 220);
            vehiculo.ChangeModelo(modelo);
            Assert.AreEqual(vehiculo.Modelo, modelo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeModeloWithEmptyModelo()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 220);
            vehiculo.ChangeModelo(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeModeloWithNullModelo()
        {
            var vehiculo = new Vehiculo("Opel", "Astra", 220);
            vehiculo.ChangeModelo(null);
        }

        [TestMethod]
        public void ChangePotenciaModifyPotencia()
        {
            int potencia = 230;
            var vehiculo = new Vehiculo("Opel", "Astra", 220);
            vehiculo.ChangePotencia(potencia);
            Assert.AreEqual(vehiculo.Potencia, potencia);
        }

    }
}
