using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Domain;
using Concesionarios.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Concesionarios.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IClienteRepository _clienteRepository;

        public ClientesService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            IClienteRepository clienteRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _clienteRepository = clienteRepository;
        }

        public void AddCliente(ClienteDTO cliente)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                _clienteRepository.Add(new Cliente());
                unitOfWork.Commit();
            }
        }
    }
}
