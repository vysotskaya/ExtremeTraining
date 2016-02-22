using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Services;
using BLL.Interface.BllEntities;
using DAL.Interface.Repositories;
using BLL.Mappers;

namespace BLL.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _uow;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IUnitOfWork uow, ICommentRepository commentRepository)
        {
            _uow = uow;
            _commentRepository = commentRepository;
        }

        public void Create(CommentEntity entity)
        {
            _commentRepository.Create(entity.ToDalComment());
            _uow.Commit();
        }

        public void Delete(CommentEntity entity)
        {
            _commentRepository.Delete(entity.ToDalComment());
            _uow.Commit();
        }

        public IEnumerable<CommentEntity> GetAll()
        {
            return _commentRepository.GetAll().Select(comment => comment.ToBllComment());
        }

        public CommentEntity GetById(int key)
        {
            return _commentRepository.GetById(key).ToBllComment();
        }

        public void Update(CommentEntity entity)
        {
            _commentRepository.Update(entity.ToDalComment());
            _uow.Commit();
        }

        public IEnumerable<CommentEntity> GetByTaskId(int taskId)
        {
            return _commentRepository.GetByTaskId(taskId).Select(comment => comment.ToBllComment());
        }
    }
}
