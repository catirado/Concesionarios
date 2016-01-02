using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF
{
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IsolationLevel _isolationLevel;

        public EFUnitOfWorkFactory(IsolationLevel isolationLevel)
        {
            _isolationLevel = isolationLevel;
        }

        public IUnitOfWork Create()
        {
            return new EFUnitOfWork(false, null);
        }
    }
}
