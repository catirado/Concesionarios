using Concesionarios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Services.Contracts
{
    //añadir coches, presupuestos, asi separamos de servicio postventa tmb a clientes
    public interface IVentasService
    {
        void AddPresupuesto(Presupuesto presupuesto);

    }
}
