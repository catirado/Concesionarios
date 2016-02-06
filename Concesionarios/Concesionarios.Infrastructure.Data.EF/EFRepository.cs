using Concesionarios.Framework.Domain;
using Concesionarios.Framework.Utils;
using Concesionarios.Infrastructure.Data.EF.Configuration;
using Concesionarios.Infrastructure.Data.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionarios.Infrastructure.Data.EF
{
    //http://stackoverflow.com/questions/10926873/unitofwork-with-unity-and-entity-framework
    //http://blog.longle.net/2013/05/11/genericizing-the-unit-of-work-pattern-repository-pattern-with-entity-framework-in-mvc/
    
    public class EFRepository<TEntity, DbContextScope>: IRepository<TEntity>  
        where DbContextScope : DbContext
        where TEntity : Entity
    {
        private readonly IAmbientDbContextLocator _ambientDbContextLocator;
        private IDbSet<TEntity> _dbSet;

        private DbContextScope DbContext
        {
            get
            {
                var dbContext = _ambientDbContextLocator.Get<DbContextScope>();

                if (dbContext == null) 
                    throw new InvalidOperationException("No ambient DbContext of type found.");

                return dbContext;
            }
        }

        protected IDbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = DbContext.Set<TEntity>();
                }
                return _dbSet;
            }
        }

        public EFRepository(IAmbientDbContextLocator ambientDbContextLocator)
        {
            Ensure.Argument.NotNull(ambientDbContextLocator, "ambientDbContextLocator");
            _ambientDbContextLocator = ambientDbContextLocator;
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
