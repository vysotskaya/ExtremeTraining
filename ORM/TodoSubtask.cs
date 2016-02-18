using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("TodoSubtasks")]
    public class TodoSubtask : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int TodoTaskRefId { get; set; }
        public int StateRefId { get; set; }

        public virtual TodoTask TodoTask { get; set; }
        public virtual State State { get; set; }

    }
}
