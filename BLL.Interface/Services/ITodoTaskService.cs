using System.Collections.Generic;
using BLL.Interface.BllEntities;

namespace BLL.Interface.Services
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTaskEntity> GetTaskEntitiesByListId(int todoListId);
        TodoTaskEntity GetTodoTaskEntity(int id);
        void CreateTodoTask(TodoTaskEntity todoTaskEntity);
        void UpdateTodoTask(TodoTaskEntity todoTaskEntity);
        void DeleteTodoTask(TodoTaskEntity todoTaskEntity);
    }
}
