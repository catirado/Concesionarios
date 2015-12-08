using Concesionarios.Domain;
using Concesionarios.Domain.Repositories;
using Concesionarios.Framework.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO.Repositories
{
    public class VehiculoRepository : ADORepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(IDBConfiguration configuration) : base(configuration) { }

        public void Add(Vehiculo entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Vehiculo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehiculo entity)
        {
            throw new NotImplementedException();
        }

        public Vehiculo Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehiculo> GetAll()
        {
            throw new NotImplementedException();
        }

        protected override void Map(System.Data.IDataRecord record, Vehiculo entity)
        {
            throw new NotImplementedException();
        }
    }
}
