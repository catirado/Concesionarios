using Concesionarios.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.ADO
{
    //https://lostechies.com/derekgreer/2015/11/01/survey-of-entity-framework-unit-of-work-patterns/
    //http://stackoverflow.com/questions/10926873/unitofwork-with-unity-and-entity-framework
    //http://stackoverflow.com/questions/10585478/one-dbcontext-per-web-request-why/10588594#10588594
    public class ADOUnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
