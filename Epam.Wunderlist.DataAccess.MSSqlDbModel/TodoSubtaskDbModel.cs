using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DataAccess.MSSqlDbModel
{
    [Table("TodoSubtasks")]
    public class TodoSubtaskDbModel
    {
        public int Id { get; private set; }
        [Required]
        public string TodoSubtaskName { get; set; }
        public int TodoTaskRefId { get; set; }
        public int TaskStateRefId { get; set; }

        public virtual TodoTaskDbModel TodoTaskDbModel { get; set; }
        public virtual TaskStateDbModel TaskStateDbModel { get; set; }

    }
}
