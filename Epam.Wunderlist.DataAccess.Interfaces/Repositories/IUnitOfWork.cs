using System;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
