using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Reflection;

namespace demo.orm
{
    public class NHibernateConfig
    {
        private static string _connectionString = "Data Source=YULONGRUAN76E6\\SQLEXPRESS; Initial Catalog=SuperHeroDB; Integrated Security=true;";

        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public NHibernateConfig() { }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                           .BuildSessionFactory();
        }

    }
}
