using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("TodoLists")]
    public class TodoList : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>(); 
        public virtual ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>(); 
    }
}
