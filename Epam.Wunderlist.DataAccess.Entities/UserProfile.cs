using System.Drawing;

namespace Epam.Wunderlist.DataAccess.Entities
{
    public class UserProfile : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Image Avatar { get; set; }  
    }
}
