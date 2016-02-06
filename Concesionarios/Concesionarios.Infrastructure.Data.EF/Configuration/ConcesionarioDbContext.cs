using Concesionarios.Domain;
using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF.Configuration
{
    public class ConcesionarioDbContext : DbContext
    {
        public ConcesionarioDbContext() : base("connectionString") //TODO: improve this
		{

        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
            //ConfigureModel(modelBuilder);
			modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ConcesionarioDbContext)));
            base.OnModelCreating(modelBuilder);
		}

        private void ConfigureModel(DbModelBuilder modelBuilder)
        {
            var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");

            var entityTypes = Assembly.GetAssembly(typeof(Vehiculo)).GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Entity)) && !x.IsAbstract);

            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
            }
        }
    }
}
