using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionarios.Domain
{
    public class Presupuesto : Entity
    {
        public string Estado { get; private set; }
        public double Importe { get; private set; }
        public Vehiculo Vehiculo { get; private set; }
        public Cliente Cliente { get; private set; }
    }
}
