using System.Collections.Generic;
using DAL.Interface.DalEntities;

namespace DAL.Interface.Repositories
{
    public interface ITodoListRepository : IRepository<DalTodoList>
    {
        ICollection<DalTodoList> GetByUserId(int userId);
    }
}
