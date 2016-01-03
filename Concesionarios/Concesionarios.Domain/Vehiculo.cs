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
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Potencia { get; private set; }

        private Vehiculo() { }

        public Vehiculo(int id, string marca, string modelo, int potencia)
        {

        }
    }
}
