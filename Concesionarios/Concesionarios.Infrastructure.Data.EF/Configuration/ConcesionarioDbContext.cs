using Concesionarios.Domain;
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
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public ConcesionarioDbContext()
            : base("connectionString") //TODO: improve this
		{

        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Overrides for the convention-based mappings.
			// We're assuming that all our fluent mappings are declared in this assembly.
			modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ConcesionarioDbContext)));
		}
    }
}
