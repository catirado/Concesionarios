using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO.Repositories
{
    public class PresupuestoRepository : ADORepository<Presupuesto>, IPresupuestoRepository
    {
        public PresupuestoRepository(IDBConfiguration configuration) : base(configuration) { }

        public IList<Presupuesto> FindAllPresupuestosForCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public IList<Presupuesto> FindAllPresupuestosForVehiculo(Vehiculo vehiculo)
        {
            throw new NotImplementedException();
        }

        public void Add(Presupuesto entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Presupuesto entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Presupuesto entity)
        {
            throw new NotImplementedException();
        }

        public Presupuesto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Presupuesto> GetAll()
        {
            throw new NotImplementedException();
        }

        protected override Presupuesto Map(IDataRecord record)
        {
            /*  return new Presupuesto(
               (int)record["Id"],
               (string)record["Nombre"],
               (string)record["Apellidos"],
               (string)record["Telefono"],
               (bool)record["Vip"]);*/
            return null;
        }
    }
}
