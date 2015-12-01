using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Domain
{
    public class Vehiculo : Entity
    {
        public string Marca { get; set; }
        public string Modelo { get; private set; }
        public int Potencia { get; private set; }

        private IList<Presupuesto> _presupuestos;

        public IList<Presupuesto> Presupuestos
        {
            get
            {
                if (_presupuestos == null)
                    _presupuestos = new List<Presupuesto>();

                return _presupuestos;
            }
            set
            {
                _presupuestos = new List<Presupuesto>(value);
            }
        }

        //mejor meter una factoria
        public Vehiculo()
        {

        }
    }
}
