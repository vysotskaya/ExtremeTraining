using DAL.Interface.DalEntities;
using ORM;

namespace DAL.Mappers
{
    public static partial class DalOrmMapper
    {
        public static DalTodoList ToDalTodoList(this TodoList todoList)
        {
            return  new DalTodoList()
            {
                Id = todoList.Id,
                Name = todoList.Name
            };
        }

        public static TodoList ToTodoList(this DalTodoList dalTodoList)
        {
            return new TodoList()
            {
                Name = dalTodoList.Name,
                Id = dalTodoList.Id
            };
        }
    }
}
