using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repositories
{
    public interface ITodoSubtaskRepository : IRepository<TodoSubtask>
    {
        ICollection<TodoSubtask> GetByTaskId(int taskId);
    }
}
