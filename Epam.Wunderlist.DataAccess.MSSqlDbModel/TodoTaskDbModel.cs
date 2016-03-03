using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DataAccess.MSSqlDbModel
{
    [Table("TodoTasks")]
    public class TodoTaskDbModel
    {
        public int Id { get; private set; }
        [Required]
        public string TodoTaskName { get; set; }
        public string TodoTaskNote { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public int TodoListRefId { get; set; }
        public int TaskStateRefId { get; set; }

        public virtual TodoListDbModel TodoListDbModel { get; set; }
        public virtual ICollection<TodoSubtaskDbModel> TodoSubtasks { get; set; }
        public virtual ICollection<AttachedTaskFileDbModel> AttachedFiles { get; set; }
        public virtual TaskStateDbModel TaskStateDbModel { get; set; }
    }
}
