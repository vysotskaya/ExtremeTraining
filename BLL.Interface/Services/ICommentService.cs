using System;
using System.Collections.Generic;
using BLL.Interface.BllEntities;

namespace BLL.Interface.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentEntity> GetAll();
        IEnumerable<CommentEntity> GetByTaskId(int taskId);
        CommentEntity GetById(int key);
        void Create(CommentEntity entity);
        void Update(CommentEntity entity);
        void Delete(CommentEntity entity);
    }
}
