using Concesionarios.Domain;
using Concesionarios.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Services.Contracts
{
    public interface IVentasService
    {
        VehiculoDTO BuscarVehiculo(int id);
        VehiculoDTO AnyadirVehiculo(VehiculoDTO vehiculo);
        void ModificarDatosVehiculo(VehiculoDTO vehiculo);
        void EliminarVehiculo(int id);
        IList<VehiculoListDTO> ListadoVehiculos();

        PresupuestoDTO BuscarPrespuesto(int id);
        PresupuestoDTO CrearPresupuesto(PresupuestoDTO presupuesto);
        PresupuestoDTO ActualizarPrespuesto(PresupuestoDTO presupuesto);
        void BorrarPresupuesto(PresupuestoDTO presupuesto);
        IList<PresupuestoListDTO> ListadoPresupuestos();

        IList<PresupuestoListDTO> BuscarPrespuestosPorVehiculo(int vehiculoId);
        IList<PresupuestoListDTO> BuscarPrespuestosPorCliente(int clienteId);
    }
}
