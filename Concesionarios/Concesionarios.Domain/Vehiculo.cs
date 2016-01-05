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

        private Vehiculo() { }

        public Vehiculo(int id, string marca, string modelo, int potencia)
        {
            Ensure.Argument.NotNull(marca, "marca");
            Ensure.Argument.NotNull(modelo, "modelo");

            this.Id = id;
            this.Modelo = modelo;
            this.Marca = marca;
            this.Potencia = potencia;
        }

        public void ChangeMarca(string marca)
        {
            Ensure.Argument.NotNull(marca, "marca");
            this.Marca = marca;
        }

        public void ChangeModelo(string modelo)
        {
            Ensure.Argument.NotNull(modelo, "modelo");
            this.Modelo = modelo;
        }

        public void ChangePotencia(int potencia)
        {
            this.Potencia = potencia;
        }

    }
}
