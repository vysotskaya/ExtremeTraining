using System.Data.Entity;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;

namespace Epam.Wunderlist.DataAccess.MSSql.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
