using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataServices.TodoListServices
{
    public interface ITodoListService
    {
        IEnumerable<TodoList> GetListEntitiesByUserId(int userId);
        TodoList GetById(int id);
        void Create(TodoList entity);
        void Update(TodoList entity);
        void Delete(TodoList entity);
    }
}
