using demo.infrastructure;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace demo.repository
{
    public class SuperHeroRepository<TEntity> : IRepository<TEntity>
    {
        private readonly ISession _session;

        public SuperHeroRepository(ISession session)
        {
            _session = session;
        }

        public void Add(TEntity entity)
        {
            _session.Save(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                _session.Save(item);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _session.Query<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _session.Delete(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                _session.Delete(item);
            }
        }

        public void Update(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }
    }
}
