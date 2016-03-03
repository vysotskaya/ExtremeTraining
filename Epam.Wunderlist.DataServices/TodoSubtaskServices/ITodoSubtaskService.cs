using System.Collections.Generic;
using Epam.Wunderlist.DataAccess.Entities;

namespace Epam.Wunderlist.DataServices.TodoSubtaskServices
{
    public interface ITodoSubtaskService
    {
        IEnumerable<TodoSubtask> GetByTaskId(int taskId);
        TodoSubtask GetById(int key);
        void Create(TodoSubtask entity);
        void Update(TodoSubtask entity);
        void Delete(TodoSubtask entity);
    }
}
