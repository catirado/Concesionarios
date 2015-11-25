using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionarios.Domain
{
    public class Presupuesto
    {
        public int Id { get; private set; }
        public string Estado { get; private set; }
        public double Importe { get; private set; }

        public Presupuesto()
        {

        }
    }
}
