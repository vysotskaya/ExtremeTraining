using System;

namespace BLL.Interface.BllEntities
{
    public class FileEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Byte[] Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int Size { get; set; }
        public int TodoTaskRefId { get; set; }
    }
}

