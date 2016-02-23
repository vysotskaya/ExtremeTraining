using BLL.Interface.BllEntities;
using DAL.Interface.DalEntities;

namespace BLL.Mappers
{
    public static partial class BllDalMappers
    {
        public static TodoTaskEntity ToTodoTaskEntity(this DalTodoTask dalTodoTask)
        {
            return new TodoTaskEntity()
            {
                Id = dalTodoTask.Id,
                Name = dalTodoTask.Name,
                StateRefId = dalTodoTask.StateRefId,
                TodoListRefId = dalTodoTask.TodoListRefId,
                Note = dalTodoTask.Note,
                CreationDate = dalTodoTask.CreationDate
            };
        }

        public static DalTodoTask ToDalTodoTask(this TodoTaskEntity todoTaskEntity)
        {
            return new DalTodoTask()
            {
                Id = todoTaskEntity.Id,
                Name = todoTaskEntity.Name,
                StateRefId = todoTaskEntity.StateRefId,
                TodoListRefId = todoTaskEntity.TodoListRefId,
                Note = todoTaskEntity.Note,
                CreationDate = todoTaskEntity.CreationDate
            };
        }
    }
}
