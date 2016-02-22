using System;

namespace DAL.Interface.DalEntities
{
    public class DalTodoTask : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }
        public int TodoListRefId { get; set; }
        public int StateRefId { get; set; }
    }
}
