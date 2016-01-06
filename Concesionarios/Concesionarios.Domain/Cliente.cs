using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
using Concesionarios.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concesionarios.Domain.Resources;

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
            string nombre, 
            string apellidos, 
            string telefono, 
            bool vip)
        {
            Ensure.Argument.NotNullOrEmpty(nombre, Messages.ClienteNombreNotNullOrEmpty);
            Ensure.Argument.NotNullOrEmpty(apellidos, Messages.ClienteApellidosNotNullOrEmpty);
            Ensure.Argument.NotNull(telefono, Messages.ClienteTelefonoNotNull);

            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Vip = vip;
        }

        public void ChangeNombre(string nombre, string apellidos)
        {
            Ensure.Argument.NotNullOrEmpty(nombre, Messages.ClienteNombreNotNullOrEmpty);
            Ensure.Argument.NotNullOrEmpty(apellidos, Messages.ClienteApellidosNotNullOrEmpty);

            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }

        public void ChangeTelefono(string telefono)
        {
            Ensure.Argument.NotNull(telefono, Messages.ClienteTelefonoNotNull);

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
