using System;


namespace DAL.Interface.DalEntities
{
    public class DalComment: IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }       
        public DateTime CreationDate { get; set; }
        public int UserRefId { get; set; }
        public int TodoTaskRefId { get; set; }
    }
}
