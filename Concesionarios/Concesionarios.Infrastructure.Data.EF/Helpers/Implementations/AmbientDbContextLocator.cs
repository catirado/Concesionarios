using Concesionarios.Infrastructure.Data.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF.Helpers.Implementations
{
    public class AmbientDbContextLocator : IAmbientDbContextLocator
    {
        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var ambientDbContextScope = EFUnitOfWork.GetAmbientScope();
            return ambientDbContextScope == null ? null : ambientDbContextScope.DbContexts.Get<TDbContext>();
        }
    }
}
