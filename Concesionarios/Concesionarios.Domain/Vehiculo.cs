using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Domain
{
    public class Vehiculo : Entity
    {
        public string Marca { get; set; }
        public string Modelo { get; private set; }
        public int Potencia { get; private set; }

        //mejor meter una factoria
        public Vehiculo()
        {

        }
    }
}
