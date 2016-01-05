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
            int id,
            Cliente cliente, 
            Vehiculo vehiculo, 
            decimal importe, 
            PresupuestoEstado estado = PresupuestoEstado.Abierto)
        {
            Ensure.Argument.NotNull(cliente, "cliente");
            Ensure.Argument.NotNull(vehiculo, "vehiculo");
            Ensure.Argument.IsNot(vehiculo.Id == 0, "Vehiculo debe tener un identificador valido");
            Ensure.Argument.IsNot(cliente.Id == 0, "Cliente debe tener un identificador valido");
            Ensure.That<ArgumentException>(importe > 0, "Importe debe ser mayor que 0");

            this.Id = id;
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
