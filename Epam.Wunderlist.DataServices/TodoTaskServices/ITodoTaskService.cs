using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataServices.TodoTaskServices
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetByListId(int todoListId);
        TodoTask GetById(int id);
        void Create(TodoTask entity);
        void Update(TodoTask entity);
        void Delete(TodoTask entity);
    }
}
