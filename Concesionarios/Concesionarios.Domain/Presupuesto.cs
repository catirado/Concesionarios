using Concesionarios.Domain.Resources;
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

        //for EF
        private Presupuesto() { }

        public Presupuesto(
            Cliente cliente, 
            Vehiculo vehiculo, 
            decimal importe, 
            PresupuestoEstado estado = PresupuestoEstado.Abierto)
        {
            Ensure.Argument.NotNull(cliente, Messages.PrespuestoClienteNotNull);
            Ensure.Argument.NotNull(vehiculo, Messages.PreuspuestoVehiculoNotNull);
            Ensure.Argument.IsNot(vehiculo.Id == 0, Messages.PrespuestoVehiculoMustHaveValidId);
            Ensure.Argument.IsNot(cliente.Id == 0, Messages.PrespuestoClienteMustHaveValidId);
            Ensure.That<ArgumentException>(importe > 0, Messages.PresupuestoImporteGreatherThanZero);

            this.Cliente = cliente;
            this.Vehiculo = vehiculo;
            this.Importe = importe;
            this.Estado = estado;
        }

        public void CambiarImporteNegociado(decimal importe)
        {
            Ensure.That<ArgumentException>(importe > 0, Messages.PresupuestoImporteGreatherThanZero);
            this.Importe = importe;
        }
        
        public void Aceptar()
        {
            if (this.Estado == PresupuestoEstado.Cerrado)
                throw new InvalidOperationException(Messages.PresupuestoAceptarNotCerrado);

            this.Estado = PresupuestoEstado.Aceptado;
        }

        public void Cerrar()
        {
            if (this.Estado == PresupuestoEstado.Cerrado)
                throw new InvalidOperationException(Messages.PresupuestoCerrarNotCerrado);

            this.Estado = PresupuestoEstado.Cerrado;
        }

        public void Reabrir()
        {
            if (this.Estado == PresupuestoEstado.Abierto)
                throw new InvalidOperationException(Messages.PresupuestoReabrirNotAbierto);

            this.Estado = PresupuestoEstado.Abierto;
        }
    }
}
