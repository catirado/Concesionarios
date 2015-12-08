using Concesionarios.Framework.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO
{
    public abstract class ADORepository<TEntity> where TEntity : new()
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
                    var item = new TEntity();
                    Map(reader, item);
                    items.Add(item);
                }
                return items;
            }
        }

        protected abstract void Map(IDataRecord record, TEntity entity);
    }
}
