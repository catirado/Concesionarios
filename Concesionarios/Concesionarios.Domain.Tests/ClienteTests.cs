using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Concesionarios.Domain.Tests
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAClienteWithEmptyNombre()
        {
            var cliente = new Cliente(0, String.Empty, "apellidos", "telefono", true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAClienteWithNullNombre()
        {
            var cliente = new Cliente(0, null, "apellidos", "telefono", true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAClienteWithEmptyApellidos()
        {
            var cliente = new Cliente(0, "nombre", String.Empty, "telefono", true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAClienteWithNullApellidos()
        {
            var cliente = new Cliente(0, "nombre", null, "telefono", true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAClienteWithNullTelefono()
        {
            var cliente = new Cliente(0, "nombre", "apellidos", null, true);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeNombreWithEmptyNombre()
        {
            var cliente = new Cliente(0, "nombre", "apellido", "telefono", true);
            cliente.ChangeNombre(String.Empty, "apellido");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeNombreWithNullNombre()
        {
            var cliente = new Cliente(0, "nombre", "apellido", "telefono", true);
            cliente.ChangeNombre(null, "apellido");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeNombreWithEmptyApellidos()
        {
            var cliente = new Cliente(0, "nombre", "apellido", "telefono", true);
            cliente.ChangeNombre("nombre", String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeNombreWithNullApellidos()
        {
            var cliente = new Cliente(0, "nombre", "apellido", "telefono", true);
            cliente.ChangeNombre("nombre", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotChangeTelefonoWithNullTelefono()
        {
            var cliente = new Cliente(0, "nombre", "apellido", "telefono", true);
            cliente.ChangeTelefono(null);
        }

    }
}
