using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Framework.Database
{
    public interface IDBConfiguration
    {
        void Setup();
        string ConnectionString { get; }
    }
}
