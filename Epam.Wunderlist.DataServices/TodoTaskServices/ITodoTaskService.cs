using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataServices.TodoTaskServices
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetByListId(int todoListId);
        TodoTask GetById(int id);
        TodoTask Create(TodoTask entity);
        void Update(TodoTask entity);
        void UpdatePriority(IEnumerable<TodoTask> list);
        void Delete(TodoTask entity);
    }
}
