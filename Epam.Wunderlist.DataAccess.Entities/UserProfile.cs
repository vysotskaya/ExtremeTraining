using System;
using Microsoft.AspNet.Identity;

namespace Epam.Wunderlist.DataAccess.Entities
{
    public class UserProfile : IUser<int>, IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Byte[] Avatar { get; set; }  
    }
}
