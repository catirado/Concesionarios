using Concesionarios.Framework.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF
{
    public class EFConfiguration : IDBConfiguration
    {
        public void Setup()
        {

        }

        public string ConnectionString
        {
            get { return "connectionString" ; }
        }
    }
}
