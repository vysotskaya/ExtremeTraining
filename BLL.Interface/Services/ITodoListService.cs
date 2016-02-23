using System.Collections.Generic;
using BLL.Interface.BllEntities;

namespace BLL.Interface.Services
{
    public interface ITodoListService
    {
        IEnumerable<TodoListEntity> GetListEntitiesByUserId(int userId);
        TodoListEntity GetTodoListEntity(int id);
        void CreateTodoList(TodoListEntity todoListEntity);
        void UpdateTodoList(TodoListEntity todoListEntity);
        void DeleteTodoList(TodoListEntity todoListEntity);
    }
}
