using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Services.DTO
{
    public class PresupuestoListDTO
    {
        public int Id { get; set; }
        public PresupuestoEstadoDTO Estado { get; set; }
        public decimal Importe { get; set; }
        public ClienteDTO Cliente { get; set; }
        public VehiculoDTO Vehiculo { get; set; }
    }
}
