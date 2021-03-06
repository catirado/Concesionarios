﻿using Concesionarios.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF.Mappings
{
    public class PresupuestoMapping : EntityTypeConfiguration<Presupuesto>
    {
        public const string TableName = "Presupuestos";

        public PresupuestoMapping()
        {
            ToTable(TableName);
            HasRequired<Vehiculo>(x => x.Vehiculo);
            HasRequired<Cliente>(x => x.Cliente);
        }
    }
}
