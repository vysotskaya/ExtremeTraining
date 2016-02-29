using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.Wunderlist.DataAccess.MSSqlDbModel
{
    [Table("UserProfiles")]
    public class UserProfileDbModel
    {
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Byte[] Avatar { get; set; }

        public virtual ICollection<TodoListDbModel> TodoLists { get; set; }
    }
}
