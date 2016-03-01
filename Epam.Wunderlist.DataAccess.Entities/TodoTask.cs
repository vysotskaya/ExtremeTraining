using System;

namespace Epam.Wunderlist.DataAccess.Entities
{
    public class TodoTask : IEntity
    {
        public int Id { get; set; }
        public string TodoTaskName { get; set; }
        public string TodoTaskNote { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public int TodoListRefId { get; set; }
        public int TaskStateRefId { get; set; }
    }
}
