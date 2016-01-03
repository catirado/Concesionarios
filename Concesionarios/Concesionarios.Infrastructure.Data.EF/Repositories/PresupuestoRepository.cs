using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Infrastructure.Data.EF.Configuration;
using Concesionarios.Infrastructure.Data.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF.Repositories
{
    public class PresupuestoRepository : EFRepository<Presupuesto, ConcesionarioDbContext>, IPresupuestoRepository
    {
        public PresupuestoRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {

        }

        public IList<Presupuesto> FindAllPresupuestosForCliente(Cliente cliente)
        {
            return base.DbSet.Where(x => x.Cliente == cliente).ToList();
        }

        public IList<Presupuesto> FindAllPresupuestosForVehiculo(Vehiculo vehiculo)
        {
            return base.DbSet.Where(x => x.Vehiculo == vehiculo).ToList();
        }
    }
}
