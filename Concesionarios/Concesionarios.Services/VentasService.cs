using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
using Concesionarios.Services.Contracts;
using Concesionarios.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Services
{
    public class VentasService : IVentasService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPresupuestoRepository _presupuestoRepository;
        private readonly IVehiculoRepository _vehiculoRepository;

        public VentasService(IUnitOfWorkFactory unitOfWorkFactory, IPresupuestoRepository presupuestoRepository, IVehiculoRepository vehiculoRepository)
        {
            Ensure.Argument.NotNull(unitOfWorkFactory, "unitOfWorkFactory");
            Ensure.Argument.NotNull(presupuestoRepository, "presupuestoRepository");
            Ensure.Argument.NotNull(vehiculoRepository, "vehiculoRepository");

            _unitOfWorkFactory = unitOfWorkFactory;
            _presupuestoRepository = presupuestoRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        public VehiculoDTO BuscarVehiculo(int id)
        {
            throw new NotImplementedException();
        }

        public VehiculoDTO AnyadirVehiculo(VehiculoDTO vehiculo)
        {
            throw new NotImplementedException();
        }

        public void ModificarDatosVehiculo(VehiculoDTO vehiculo)
        {
            throw new NotImplementedException();
        }

        public void EliminarVehiculo(int id)
        {
            throw new NotImplementedException();
        }

        public IList<VehiculoListDTO> ListadoVehiculos()
        {
            throw new NotImplementedException();
        }

        public PresupuestoDTO BuscarPrespuesto(int id)
        {
            throw new NotImplementedException();
        }

        public PresupuestoDTO CrearPresupuesto(PresupuestoDTO presupuesto)
        {
            throw new NotImplementedException();
        }

        public PresupuestoDTO ActualizarPrespuesto(PresupuestoDTO presupuesto)
        {
            throw new NotImplementedException();
        }

        public void BorrarPresupuesto(PresupuestoDTO presupuesto)
        {
            throw new NotImplementedException();
        }

        public IList<PresupuestoListDTO> ListadoPresupuestos()
        {
            throw new NotImplementedException();
        }

        public IList<PresupuestoListDTO> BuscarPrespuestosPorVehiculo(int vehiculoId)
        {
            throw new NotImplementedException();
        }

        public IList<PresupuestoListDTO> BuscarPrespuestosPorCliente(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
