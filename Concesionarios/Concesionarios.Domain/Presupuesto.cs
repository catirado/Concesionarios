using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionarios.Domain
{
    public class Presupuesto : Entity
    {
        public string Estado { get; set; }
        public double Importe { get; set; }
        private Vehiculo Vehiculo { get; set; }
        private Cliente Cliente { get; set; }
    }
}
