using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repositories
{
    public interface ITodoListRepository : IRepository<TodoList>
    {
        ICollection<TodoList> GetByUserId(int userId);
    }
}
