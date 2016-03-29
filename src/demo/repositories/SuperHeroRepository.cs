using demo.infrastructure;
using demo.orm;
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
        private UnitOfWork _unitOfWork;
        protected ISession _session { get { return _unitOfWork.Session; } }

        public SuperHeroRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
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
