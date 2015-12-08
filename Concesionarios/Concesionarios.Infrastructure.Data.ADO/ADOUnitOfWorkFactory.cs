using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Concesionarios.Infrastructure.Data.ADO
{
    public class ADOUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IsolationLevel _isolationLevel;

        public ADOUnitOfWorkFactory(IsolationLevel isolationLevel)
        {
            _isolationLevel = isolationLevel;
        }

        public IUnitOfWork Create()
        {
            return new ADOUnitOfWork(_isolationLevel);
        }
    }
}
