using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionarios.Domain
{
    public class Presupuesto : Entity
    {
        public enum PresupuestoEstado { Abierto, Aceptado, Cerrado}

        public PresupuestoEstado Estado { get; private set; }
        public decimal Importe { get; private set; }
        public virtual Vehiculo Vehiculo { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        private Presupuesto() { }

        public Presupuesto(
            Cliente cliente, 
            Vehiculo vehiculo, 
            decimal importe, 
            PresupuestoEstado estado = PresupuestoEstado.Abierto)
        {
            //TODO: ensure that tienen id
            Ensure.Argument.NotNull(cliente, "cliente");
            Ensure.Argument.NotNull(vehiculo, "vehiculo");
            Ensure.That<ArgumentException>(importe > 0, "Importe debe ser mayor que 0");

            this.Cliente = cliente;
            this.Vehiculo = vehiculo;
            this.Importe = importe;
            this.Estado = estado;
        }

        public void CambiarImporteNegociado(decimal importe)
        {
            Ensure.That<ArgumentException>(importe > 0, "Importe debe ser mayor que 0");
            this.Importe = importe;
        }
        
        public void Aceptar()
        {
            this.Estado = PresupuestoEstado.Aceptado;
        }

        public void Cerrar()
        {
            this.Estado = PresupuestoEstado.Cerrado;
        }

        public void Reabrir()
        {
            this.Estado = PresupuestoEstado.Abierto;
        }
    }
}
