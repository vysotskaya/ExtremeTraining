using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Files")]
    public class File : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Byte[] Content { get; set; }
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public int Size => Content?.Length ?? 0;
        public int TodoTaskRefId { get; set; }

        public virtual TodoTask TodoTask { get; set; }
    }
}
