using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
using Concesionarios.Framework.Extensions;
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
            Ensure.Argument.NotNullOrEmpty(nombre, "El nombre debe ser rellenado");
            Ensure.Argument.NotNullOrEmpty(apellidos, "Los apellidos deben ser rellenados");
            Ensure.Argument.NotNull(telefono, "El telefono no debe ser nulo");

            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Vip = vip;
        }

        public void ChangeNombre(string nombre, string apellidos)
        {
            Ensure.Argument.NotNullOrEmpty(nombre, "El nombre debe ser rellenado");
            Ensure.Argument.NotNullOrEmpty(apellidos, "Los apellidos deben ser rellenados");

            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }

        public void ChangeTelefono(string telefono)
        {
            Ensure.Argument.NotNull(telefono, "El telefono no debe ser nulo");

            this.Telefono = telefono;
        }

        public void SetVip(bool vip)
        {
            this.Vip = vip;
        }

        public string NombreCompleto
        {
            get { return "{0} {1}".FormatWith(Nombre, Apellidos); }
        }
    }
}
