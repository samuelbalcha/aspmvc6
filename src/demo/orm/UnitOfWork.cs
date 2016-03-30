using System;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

using System.Reflection;
using demo.orm.Mappings;
using demo.models;

namespace demo.orm
{
    public class UnitOfWork : IUnitOfWork
    {
        private static string _connectionString = "Data Source=YULONGRUAN76E6\\SQLEXPRESS; Initial Catalog=SHDB; Integrated Security=true;";

        private static readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;
        protected static Configuration _NHConf;
      
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
            _NHConf = ConfigureNH();
            HbmMapping mapping = GetMappings();
            _NHConf.AddDeserializedMapping(mapping, "SHDB");
            SchemaMetadataUpdater.QuoteTableAndColumns(_NHConf);
            new SchemaUpdate(_NHConf).Execute(true, true);

            return _NHConf.BuildSessionFactory();

            //return Fluently.Configure()
            //               .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
            //               .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
            //               .BuildSessionFactory();
        }

        private static Configuration ConfigureNH()
        {
            var conf = new Configuration();
            conf.SessionFactoryName("SetupDB");
            conf.DataBaseIntegration( db => 
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = _connectionString;
                db.Timeout = 10;

                // testing
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });

            return conf;
        }

        protected static HbmMapping GetMappings()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping<SuperHeroMap>();
            mapper.AddMapping<SuperPowerMap>();

            HbmMapping mapping = mapper.CompileMappingFor(new[] { typeof(SuperHero), typeof(SuperPower) });

            return mapping;
        }

    }
}
