using ORM;
using DAL.Interface.DalEntities;

namespace DAL.Mappers
{
    public static class DalTodoSubtaskMapper
    {
        public static TodoSubtask ToTodoSubtask (this DalTodoSubtask dalEntity )
        {
            return new TodoSubtask()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                StateRefId = dalEntity.StateRefId,
                TodoTaskRefId = dalEntity.TodoTaskRefId
            };
        }

        public static DalTodoSubtask ToDalTodoSubtask(this TodoSubtask entity)
        {
            return new DalTodoSubtask()
            {
                Id = entity.Id,
                Name = entity.Name,
                StateRefId = entity.StateRefId,
                TodoTaskRefId = entity.TodoTaskRefId
            };
        }
    }
}
