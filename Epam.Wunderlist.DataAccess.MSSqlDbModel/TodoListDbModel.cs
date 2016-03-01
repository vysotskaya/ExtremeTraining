using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DataAccess.MSSqlDbModel
{
    [Table("TodoLists")]
    public class TodoListDbModel
    {
        public int Id { get; private set; }
        [Required]
        public string TodoListName { get; set; }
        public int UserProfileRefId { get; set; }

        public virtual UserProfileDbModel UserProfile { get; set; }
        public virtual ICollection<TodoTaskDbModel> TodoTasks { get; set; } 
    }
}
