using System;
namespace BLL.Interface.BllEntities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserRefId { get; set; }
        public int TodoTaskRefId { get; set; }
    }
}
