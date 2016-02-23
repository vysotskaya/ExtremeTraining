using System;

namespace DAL.Interface.DalEntities
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Byte[] Photo { get; set; }
    }
}
