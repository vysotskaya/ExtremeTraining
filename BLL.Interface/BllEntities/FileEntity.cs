using System;

namespace BLL.Interface.BllEntities
{
    public class FileEntity: BaseEntity
    {
        public string Name { get; set; }
        public Byte[] Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int Size { get; set; }
        public int TodoTaskRefId { get; set; }
    }
}

