using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Concesionarios.Infrastructure.Data.ADO
{
    //https://lostechies.com/derekgreer/2015/11/01/survey-of-entity-framework-unit-of-work-patterns/
    //http://stackoverflow.com/questions/10926873/unitofwork-with-unity-and-entity-framework
    //http://stackoverflow.com/questions/10585478/one-dbcontext-per-web-request-why/10588594#10588594
    //http://www.codeproject.com/Articles/690136/All-About-TransactionScope
    //http://codereview.stackexchange.com/questions/77610/reusable-unit-of-work-interface-factory
    public class ADOUnitOfWork : IUnitOfWork
    {

        private bool disposed = false;

        private readonly TransactionScope transactionScope;

        public ADOUnitOfWork(System.Transactions.IsolationLevel isolationLevel)
        {
            this.transactionScope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions
                    {
                        IsolationLevel = isolationLevel,
                        Timeout = TransactionManager.MaximumTimeout
                    });
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.transactionScope.Dispose();
                }

                disposed = true;
            }
        }

        public void Commit()
        {
            this.transactionScope.Complete();
        }
    }

}
