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
    public class VehiculoRepository : EFRepository<Vehiculo, ConcesionarioDbContext>, IVehiculoRepository
    {
        public VehiculoRepository(IAmbientDbContextLocator ambientDbContextLocator)
            : base(ambientDbContextLocator)
        {
        }
    }
}
