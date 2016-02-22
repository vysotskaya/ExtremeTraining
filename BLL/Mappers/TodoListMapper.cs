using BLL.Interface.BllEntities;
using DAL.Interface.DalEntities;

namespace BLL.Mappers
{
    public static partial class BllDalMappers
    {
        public static TodoListEntity ToTodoListEntity(this DalTodoList dalTodoList)
        {
            return new TodoListEntity()
            {
                Id = dalTodoList.Id,
                Name = dalTodoList.Name
            };
        }

        public static DalTodoList ToDalListEntity(this TodoListEntity todoListEntity)
        {
            return new DalTodoList()
            {
                Id = todoListEntity.Id,
                Name = todoListEntity.Name
            };
        }
    }
}
