using System;


namespace DAL.Interface.DalEntities
{
    public class DalFile: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Byte[] Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int Size { get; set; }
        public int TodoTaskRefId { get; set; }
    }
}
