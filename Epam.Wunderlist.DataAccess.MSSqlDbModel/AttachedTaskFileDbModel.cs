using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DataAccess.MSSqlDbModel
{
    [Table("AttachedFiles")]
    public class AttachedTaskFileDbModel
    {
        public int Id { get; private set; }
        [Required]
        public string FileName { get; set; }
        public Byte[] Content { get; set; }
        public DateTime DateAdded { get; set; }
        [NotMapped]
        public int Size => Content?.Length ?? 0;
        public int TodoTaskRefId { get; set; }

        public virtual TodoTaskDbModel TodoTaskDbModel { get; set; }
    }
}
