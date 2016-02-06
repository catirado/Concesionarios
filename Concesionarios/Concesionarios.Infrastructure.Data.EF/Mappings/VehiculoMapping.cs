using Concesionarios.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF.Mappings
{
    public class VehiculoMapping : EntityTypeConfiguration<Vehiculo>
    {
        public const string TableName = "Vehiculos";

        public VehiculoMapping()
        {
            ToTable(TableName);
        }
    }
}
