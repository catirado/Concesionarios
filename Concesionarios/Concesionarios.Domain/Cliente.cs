using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Domain
{
    public class Cliente : Entity
    {
        public string Nombre { get; private set; }
        public string Apellidos { get; private set; }
        public string Telefono { get; private set; }
        public bool Vip { get; private set; }

        public Cliente()
        {

        }

        public Cliente(string nombre, string apellidos, string telefono, bool vip)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Vip = vip;
        }
    }
}
