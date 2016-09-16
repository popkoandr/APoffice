using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace APoffice.RepositoryFolder
{
    public interface IRepository<TEntity> where TEntity:class
    {
        TEntity Get(Guid id);
                                        // what is ienumrable
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);//for lambda expression (LINQ)

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}