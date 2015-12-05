using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Framework.Domain
{
    public interface IRepository<T> where T:Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
