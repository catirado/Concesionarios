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
        
        //for EF
        private Cliente() { }

        public Cliente(
            int id, 
            string nombre, 
            string apellidos, 
            string telefono, 
            bool vip)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Vip = vip;
        }

        public void ChangeName(string name, string apellidos)
        {
            this.Nombre = name;
            this.Apellidos = apellidos;
        }

        public void ChangePhone(string phone)
        {
            this.Telefono = phone;
        }

        //set vip
    }
}
