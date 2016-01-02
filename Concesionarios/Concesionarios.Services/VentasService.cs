using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Domain;
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

        public VentasService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IPresupuestoRepository presupuestoRepository,
            IVehiculoRepository vehiculoRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _presupuestoRepository = presupuestoRepository;
            _vehiculoRepository = vehiculoRepository;
        }

    }
}
