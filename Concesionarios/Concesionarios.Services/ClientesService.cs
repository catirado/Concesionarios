using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
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

        public ClientesService(IUnitOfWorkFactory unitOfWorkFactory, IClienteRepository clienteRepository)
        {
            Ensure.Argument.NotNull(unitOfWorkFactory, "unitOfWorkFactory");
            Ensure.Argument.NotNull(clienteRepository, "clienteRepository");

            _unitOfWorkFactory = unitOfWorkFactory;
            _clienteRepository = clienteRepository;
        }

        public ClienteDTO AltaCliente(ClienteDTO clienteDTO)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                Ensure.Argument.NotNull(clienteDTO, "cliente not null");

                var cliente = new Cliente(0, 
                                         clienteDTO.Nombre, 
                                         clienteDTO.Apellidos, 
                                         clienteDTO.Telefono, 
                                         clienteDTO.Vip);

                _clienteRepository.Add(cliente);
                unitOfWork.Commit();

                return clienteDTO;
            }
        }

        public void BajaCliente(ClienteDTO cliente)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                _clienteRepository.Remove(new Cliente(0, "","","",true));
                unitOfWork.Commit();
            }
        }

        public void ActualizarDatosCliente(ClienteDTO cliente)
        {
            throw new NotImplementedException();
        }

        public IList<ClienteDTO> ListadoClientes()
        {
            throw new NotImplementedException();
        }
    }
}
