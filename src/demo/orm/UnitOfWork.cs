using System;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;

namespace demo.orm
{
    public class UnitOfWork : IUnitOfWork
    {
        private static string _connectionString = "Data Source=YULONGRUAN76E6\\SQLEXPRESS; Initial Catalog=SuperHeroDB; Integrated Security=true;";

        private static readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            _sessionFactory = CreateSessionFactory();
        }

        public UnitOfWork()
        {
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

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                           .BuildSessionFactory();
        }
    }
}
