using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace APoffice.RepositoryFolder
{
    //2nd  - implement interface on base generic class  
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //dependency field
        protected readonly DbContext Context;

        //inject depyndency through constructor
        public Repository(DbContext context)
        {
            Context = context;
        }
        #region Methods
        public TEntity Get(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()// doesn`t return IQueryale
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);

        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion
    }
}