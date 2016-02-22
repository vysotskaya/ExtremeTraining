using System.Drawing;

namespace BLL.Interface.BllEntities
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Image Photo { get; set; }
    }
}
