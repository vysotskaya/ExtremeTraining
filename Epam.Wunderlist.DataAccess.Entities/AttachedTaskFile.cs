using System;

namespace Epam.Wunderlist.DataAccess.Entities
{
    public class AttachedTaskFile : IEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Byte[] Content { get; set; }
        public DateTime DateAdded { get; set; }
        public int Size { get; set; }
        public int TodoTaskRefId { get; set; } 
    }
}
