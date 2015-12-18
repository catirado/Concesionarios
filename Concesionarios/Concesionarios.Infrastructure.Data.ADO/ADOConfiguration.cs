using Concesionarios.Framework.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO
{
    public class ADODBConfiguration : IDBConfiguration
    {
        private string _connectionString;

        public ADODBConfiguration(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Setup()
        {
            //this can be empty
        }

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
    }
}
