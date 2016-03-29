using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace demo.infrastructure
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
    }
}
