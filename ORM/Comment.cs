using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
        public int UserRefId { get; set; }
        public int TodoTaskRefId { get; set; }

        public virtual User User { get; set; }
        public virtual TodoTask TodoTask { get; set; }
    }
}
