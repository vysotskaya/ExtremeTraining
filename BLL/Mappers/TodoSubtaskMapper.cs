using DAL.Interface.DalEntities;
using BLL.Interface.BllEntities;

namespace BLL.Mappers
{
    public static  class TodoSubtaskMapper
    {
        public static DalTodoSubtask ToDalTodoSubtask(this TodoSubtaskEntity bllEntity)
        {
            return new DalTodoSubtask()
            {
                Id = bllEntity.Id,
                Name = bllEntity.Name,
                TodoTaskRefId = bllEntity.TodoTaskRefId,
                StateRefId = bllEntity.StateRefId
            };
        }

        public static TodoSubtaskEntity ToBllToDoSubtask(this DalTodoSubtask dalEntity)
        {
            return new TodoSubtaskEntity()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                TodoTaskRefId = dalEntity.TodoTaskRefId,
                StateRefId = dalEntity.StateRefId
            };
        }
    }
}
