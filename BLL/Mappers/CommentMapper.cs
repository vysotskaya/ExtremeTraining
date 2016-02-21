using System;
using DAL.Interface.DalEntities;
using BLL.Interface.BllEntities;

namespace BLL.Mappers
{
    public static class CommentMapper
    {
        public static DalComment ToDalComment(this CommentEntity bllEntity)
        {
            return new DalComment()
            {
                Id = bllEntity.Id,
                Content = bllEntity.Content,
                CreationDate = bllEntity.CreationDate,
                TodoTaskRefId = bllEntity.TodoTaskRefId,
                UserRefId = bllEntity.UserRefId
            };
        }

        public static CommentEntity ToBllComment(this DalComment dalEntity)
        {
            return new CommentEntity()
            {
                Id = dalEntity.Id,
                Content = dalEntity.Content,
                CreationDate = dalEntity.CreationDate,
                TodoTaskRefId = dalEntity.TodoTaskRefId,
                UserRefId = dalEntity.UserRefId
            };
        }
    }
}
