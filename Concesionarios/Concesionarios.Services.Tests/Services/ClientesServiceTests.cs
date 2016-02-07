using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Services.Tests.Services
{
    [TestClass]
    public class ClientesServiceTests
    {
        public ClientesServiceTests()
        {

        }

        //para los demás métodos...

        //BuscarCliente

        //AltaCliente

        //BajaCliente

        //ActualizarDatosCliente

        //ListadoClientes

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowExceptionWhenUnitOfWorkFactoryDependencyIsNull()
        {
            IUnitOfWorkFactory unitOfWorkFactory = null;
            var clienteRepository = GetSubstituteOfClienteRepository();
            var clienteService = new ClientesService(unitOfWorkFactory, clienteRepository);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowExceptionWhenClienteRepositoryDependencyIsNull()
        {
            IUnitOfWorkFactory unitOfWorkFactory = GetSubstituteOfUnitOfWorkFactory();
            IClienteRepository clienteRepository = null;
            var clienteService = new ClientesService(unitOfWorkFactory, clienteRepository);
        }

        private IClienteRepository GetSubstituteOfClienteRepository()
        {
            var repository = Substitute.For<IClienteRepository>();
            return repository;
        }

        private IUnitOfWork GetMockUnitOfWork()
        {
            var uow = Substitute.For<IUnitOfWork>();
            return uow;
        }

        private IUnitOfWorkFactory GetSubstituteOfUnitOfWorkFactory()
        {
            var uowFactory = Substitute.For<IUnitOfWorkFactory>();
            uowFactory.Create().Returns(GetMockUnitOfWork());
            return uowFactory;
        }
    }
}
