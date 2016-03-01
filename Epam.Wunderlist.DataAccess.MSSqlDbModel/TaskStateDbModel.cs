using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DataAccess.MSSqlDbModel
{
    [Table("TaskStates")]
    public class TaskStateDbModel
    {
        public int Id { get; private set; }
        [Required]
        public string TaskStateName { get; set; }

        public virtual ICollection<TodoSubtaskDbModel> TodoSubtasks { get; set; }
        public virtual ICollection<TodoTaskDbModel> TodoTasks { get; set; }
    }
}
