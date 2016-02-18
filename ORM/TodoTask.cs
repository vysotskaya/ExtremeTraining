using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("TodoTasks")]
    public class TodoTask : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }
        public int TodoListRefId { get; set; }
        public int StateRefId { get; set; }

        public virtual TodoList TodoList { get; set; }
        public virtual ICollection<TodoSubtask> TodoSubtasks { get; set; } = new List<TodoSubtask>();
        public virtual ICollection<File> Files { get; set; } = new List<File>();
        public virtual State State { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
