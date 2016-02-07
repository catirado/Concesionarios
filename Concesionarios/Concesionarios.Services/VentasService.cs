using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
using Concesionarios.Services.Contracts;
using Concesionarios.Services.DTO;
using Concesionarios.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpressMapper.Extensions;

namespace Concesionarios.Services
{
    public class VentasService : IVentasService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPresupuestoRepository _presupuestoRepository;
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IClienteRepository _clienteRepository;

        public VentasService(IUnitOfWorkFactory unitOfWorkFactory, 
                             IPresupuestoRepository presupuestoRepository, 
                             IVehiculoRepository vehiculoRepository,
                             IClienteRepository clienteRepository)
        {
            Ensure.Argument.NotNull(unitOfWorkFactory, "unitOfWorkFactory");
            Ensure.Argument.NotNull(presupuestoRepository, "presupuestoRepository");
            Ensure.Argument.NotNull(vehiculoRepository, "vehiculoRepository");
            Ensure.Argument.NotNull(clienteRepository, "clienteRepository");

            _unitOfWorkFactory = unitOfWorkFactory;
            _presupuestoRepository = presupuestoRepository;
            _vehiculoRepository = vehiculoRepository;
            _clienteRepository = clienteRepository;
        }

        public VehiculoDTO BuscarVehiculo(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var vehiculo = _vehiculoRepository.Get(id);
                Ensure.NotNull<NotFoundException>(vehiculo, String.Format("Vehiculo with id {0} not found", id));
                return vehiculo.Map<Vehiculo, VehiculoDTO>();
            }
        }

        public VehiculoDTO AnyadirVehiculo(VehiculoDTO vehiculoDTO)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                Ensure.Argument.NotNull(vehiculoDTO, "vehiculo not null");

                var vehiculo = new Vehiculo(vehiculoDTO.Marca, vehiculoDTO.Modelo, vehiculoDTO.Potencia);

                _vehiculoRepository.Add(vehiculo);
                unitOfWork.Commit();

                return vehiculo.Map<Vehiculo, VehiculoDTO>();
            }
        }

        public void ModificarDatosVehiculo(VehiculoDTO vehiculoDTO)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                Ensure.Argument.NotNull(vehiculoDTO, "vehiculo not null");

                var vehiculo = _vehiculoRepository.Get(vehiculoDTO.Id);
                Ensure.NotNull<NotFoundException>(vehiculo, String.Format("Vehiculo with id {0} not found", vehiculoDTO.Id));

                vehiculo.ChangeMarca(vehiculoDTO.Marca);
                vehiculo.ChangeModelo(vehiculoDTO.Modelo);
                vehiculo.ChangePotencia(vehiculoDTO.Potencia);

                _vehiculoRepository.Update(vehiculo);
                unitOfWork.Commit();

                vehiculoDTO = vehiculo.Map<Vehiculo, VehiculoDTO>();
            }
        }

        public void EliminarVehiculo(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var vehiculo = _vehiculoRepository.Get(id);
                if (vehiculo != null)
                {
                    _vehiculoRepository.Remove(vehiculo);
                }
                unitOfWork.Commit();
            }
        }

        public IList<VehiculoListDTO> ListadoVehiculos()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return _vehiculoRepository.GetAll().Map<IEnumerable<Vehiculo>, IList<VehiculoListDTO>>();
            }
        }

        public PresupuestoDTO BuscarPrespuesto(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var presupuesto = _presupuestoRepository.Get(id);
                Ensure.NotNull<NotFoundException>(presupuesto, String.Format("Presupueto with id {0} not found", id));
                return presupuesto.Map<Presupuesto, PresupuestoDTO>();
            }
        }

        public PresupuestoDTO CrearPresupuesto(PresupuestoDTO presupuestoDTO)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                Ensure.Argument.NotNull(presupuestoDTO, "presupuesto not null");
                Ensure.Argument.NotNull(presupuestoDTO.Cliente, "cliente not null");
                Ensure.Argument.NotNull(presupuestoDTO.Vehiculo, "vehiculo not null");

                var cliente = _clienteRepository.Get(presupuestoDTO.Cliente.Id);
                Ensure.NotNull<NotFoundException>(cliente, String.Format("cliente with id {0} not found", presupuestoDTO.Cliente.Id));
                var vehiculo = _vehiculoRepository.Get(presupuestoDTO.Vehiculo.Id);
                Ensure.NotNull<NotFoundException>(vehiculo, String.Format("vehiculo with id {0} not found", presupuestoDTO.Vehiculo.Id));
                var presupuesto = new Presupuesto(cliente, vehiculo, presupuestoDTO.Importe);

                _presupuestoRepository.Add(presupuesto);
                unitOfWork.Commit();

                return presupuesto.Map<Presupuesto, PresupuestoDTO>();
            }
        }

        public PresupuestoDTO ActualizarPrespuesto(PresupuestoDTO presupuestoDTO)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                Ensure.Argument.NotNull(presupuestoDTO, "presupuesto not null");

                var presupuesto = _presupuestoRepository.Get(presupuestoDTO.Id);
                Ensure.NotNull<NotFoundException>(presupuesto, String.Format("Presupuesto with id {0} not found", presupuestoDTO.Id));

                presupuesto.CambiarImporteNegociado(presupuestoDTO.Importe);

                _presupuestoRepository.Update(presupuesto);
                unitOfWork.Commit();

                return presupuesto.Map<Presupuesto, PresupuestoDTO>();
            }
        }

        public void BorrarPresupuesto(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var presupuesto = _presupuestoRepository.Get(id);
                if (presupuesto != null)
                {
                    _presupuestoRepository.Remove(presupuesto);
                }
                unitOfWork.Commit();
            }
        }

        public IList<PresupuestoListDTO> ListadoPresupuestos()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return _presupuestoRepository.GetAll().Map<IEnumerable<Presupuesto>, IList<PresupuestoListDTO>>();
            }
        }

        public IList<PresupuestoListDTO> BuscarPrespuestosPorVehiculo(int vehiculoId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return _presupuestoRepository.FindAllPresupuestosByVehiculo(vehiculoId).Map<IEnumerable<Presupuesto>, IList<PresupuestoListDTO>>();
            }
        }

        public IList<PresupuestoListDTO> BuscarPrespuestosPorCliente(int clienteId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return _presupuestoRepository.FindAllPresupuestosByCliente(clienteId).Map<IEnumerable<Presupuesto>, IList<PresupuestoListDTO>>();
            }
        }
    }
}
