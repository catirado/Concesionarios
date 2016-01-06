using Concesionarios.Domain.Resources;
using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
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

        //for EF
        private Vehiculo() { }

        public Vehiculo(string marca, string modelo, int potencia)
        {
            Ensure.Argument.NotNullOrEmpty(marca, Messages.VehiculoMarcaNotNullOrEmpty);
            Ensure.Argument.NotNullOrEmpty(modelo, Messages.VehiculoModeloNotNullOrEmpty);

            this.Modelo = modelo;
            this.Marca = marca;
            this.Potencia = potencia;
        }

        public void ChangeMarca(string marca)
        {
            Ensure.Argument.NotNullOrEmpty(marca, Messages.VehiculoMarcaNotNullOrEmpty);
            this.Marca = marca;
        }

        public void ChangeModelo(string modelo)
        {
            Ensure.Argument.NotNullOrEmpty(modelo, Messages.VehiculoModeloNotNullOrEmpty);
            this.Modelo = modelo;
        }

        public void ChangePotencia(int potencia)
        {
            this.Potencia = potencia;
        }

    }
}
