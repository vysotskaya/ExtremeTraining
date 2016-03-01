using System.Drawing;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Epam.Wunderlist.DataAccess.Entities
{
    public class UserProfile : IdentityUser, IEntity
    {
        new public int Id { get; set; }
        public string Name { get; set; }
        new public string Email { get; set; }
        public string Password { get; set; }
        public Image Avatar { get; set; }  
    }
}
