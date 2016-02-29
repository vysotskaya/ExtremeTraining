using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repositories
{
    public interface ITodoTaskRepository : IRepository<TodoTask>
    {
        ICollection<TodoTask> GetByTodoListId(int listId);
    }
}
