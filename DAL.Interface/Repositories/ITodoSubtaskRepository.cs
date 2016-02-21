using System;
using System.Collections.Generic;
using DAL.Interface.DalEntities;

namespace DAL.Interface.Repositories
{
    public interface ITodoSubtaskRepository : IRepository<DalTodoSubtask>
    {
        IEnumerable<DalTodoSubtask> GetByTaskId(int taskId);
        IEnumerable<DalTodoSubtask> GetBySate(int stateId);
    }
}
