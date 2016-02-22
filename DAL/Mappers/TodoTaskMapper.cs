using DAL.Interface.DalEntities;
using ORM;

namespace DAL.Mappers
{
    public static partial class DalOrmMapper
    {
        public static DalTodoTask ToDalTodoTask(this TodoTask todoTask)
        {
            return new DalTodoTask()
            {
                Name = todoTask.Name,
                Id = todoTask.Id,
                StateRefId = todoTask.StateRefId,
                CreationDate = todoTask.CreationDate,
                Note = todoTask.Note,
                TodoListRefId = todoTask.TodoListRefId
            };
        }

        public static TodoTask ToTodoTask(this DalTodoTask dalTodoTask)
        {
            return new TodoTask()
            {
                Name = dalTodoTask.Name,
                Id = dalTodoTask.Id,
                StateRefId = dalTodoTask.StateRefId,
                CreationDate = dalTodoTask.CreationDate,
                Note = dalTodoTask.Note,
                TodoListRefId = dalTodoTask.TodoListRefId
            };
        }
    }
}
