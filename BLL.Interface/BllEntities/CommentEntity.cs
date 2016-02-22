using System;
namespace BLL.Interface.BllEntities
{
    public class CommentEntity: BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserRefId { get; set; }
        public int TodoTaskRefId { get; set; }
    }
}
