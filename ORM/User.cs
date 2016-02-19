using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Byte[] Photo { get; set; }

        public virtual ICollection<TodoList> TodoLists { get; set; } = new List<TodoList>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>(); 
    }
}
