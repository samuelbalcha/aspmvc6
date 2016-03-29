using System;
using NHibernate;

namespace demo.orm
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;

        public ISession Session { get; private set; }

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        public void Complete()
        {
            if (_transaction == null || !_transaction.IsActive)
                throw new InvalidOperationException("UnitOfWork have already been saved.");

            _transaction.Commit();
        }

        public void Dispose()
        {
            Session.Close();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }
    }
}
