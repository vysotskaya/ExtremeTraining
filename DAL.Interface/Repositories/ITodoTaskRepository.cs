using System.Collections.Generic;
using DAL.Interface.DalEntities;

namespace DAL.Interface.Repositories
{
    public interface ITodoTaskRepository : IRepository<DalTodoTask>
    {
        ICollection<DalTodoTask> GetByTodoListId(int listId);
    }
}
