using System;
using NHibernate;

namespace demo.orm
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Complete();
        void Rollback();
    }
}
