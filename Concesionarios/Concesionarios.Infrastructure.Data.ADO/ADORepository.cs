using Concesionarios.Framework.Database;
using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO
{
    public abstract class ADORepository<TEntity> where TEntity : Entity
    {
        protected readonly string _connectionString;

        public ADORepository(IDBConfiguration configuration)
        {
            _connectionString = configuration.ConnectionString;
        }

        protected IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (reader.Read())
                {
                    var item = Map(reader);
                    items.Add(item);
                }
                return items;
            }
        }

        protected abstract TEntity Map(IDataRecord record);
    }
}
