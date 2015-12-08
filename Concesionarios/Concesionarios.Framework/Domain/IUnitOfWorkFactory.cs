using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Concesionarios.Framework.Domain
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
