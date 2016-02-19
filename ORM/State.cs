using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("States")]
    public class State : BaseEntity
    {
        [Required]
        public string StateName { get; set; }

        public virtual ICollection<TodoSubtask> TodoSubtasks { get; set; } = new List<TodoSubtask>();
        public virtual ICollection<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
    }
}
