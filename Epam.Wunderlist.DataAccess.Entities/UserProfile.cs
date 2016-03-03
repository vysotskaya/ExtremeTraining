using System.Drawing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Epam.Wunderlist.DataAccess.Entities
{
    public class UserProfile : IUser<int>, IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        //public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Image Avatar { get; set; }  
    }
}
