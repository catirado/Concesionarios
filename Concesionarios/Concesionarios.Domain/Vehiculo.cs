using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Domain
{
    public class Vehiculo
    {
        public int Id { get; private set; }
        public string Marca { get; set; }
        public string Modelo { get; private set; }
        public int Potencia { get; private set; }
        public IList<Presupuesto> Presupuestos {get; private set;}

        public Vehiculo()
        {

        }
    }
}
