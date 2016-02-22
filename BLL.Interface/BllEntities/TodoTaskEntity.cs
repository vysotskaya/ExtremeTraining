using System;

namespace BLL.Interface.BllEntities
{
    public class TodoTaskEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }
        public int TodoListRefId { get; set; }
        public int StateRefId { get; set; }
    }
}
