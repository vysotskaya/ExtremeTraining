using ORM;
using DAL.Interface.DalEntities;

namespace DAL.Mappers
{
    public static class DalCommentMapper
    {
        public static Comment ToComment (this DalComment dalEntity)
        {
            return new Comment()
            {
                Id = dalEntity.Id,
                Content = dalEntity.Content,
                CreationDate = dalEntity.CreationDate,
                TodoTaskRefId = dalEntity.TodoTaskRefId,
                UserRefId = dalEntity.UserRefId
            };
        }
        public static DalComment ToDalComment(this Comment entity)
        {
            return new DalComment()
            {
                Id = entity.Id,
                Content = entity.Content,
                CreationDate = entity.CreationDate,
                TodoTaskRefId = entity.TodoTaskRefId,
                UserRefId = entity.UserRefId
            };
        }
    
}
}
