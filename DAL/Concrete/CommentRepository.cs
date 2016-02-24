﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DalEntities;
using DAL.Interface.Repositories;
using System.Data.Entity;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext _dbContext;

        public CommentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(DalComment entity)
        {
            var comment = entity?.ToComment();
            _dbContext.Set<Comment>().Add(comment);
        }

        public void Delete(DalComment entity)
        {
            var removeComment = _dbContext.Set<Comment>().FirstOrDefault(comment => comment.Id == entity.Id);
            if (removeComment != null)
            {
                _dbContext.Set<Comment>().Remove(removeComment);
            }
        }

        public IEnumerable<DalComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalComment GetById(int key)
        {
            return _dbContext.Set<Comment>().FirstOrDefault(comment => comment.Id == key)?.ToDalComment();
        }

        public DalComment GetByPredicate(Expression<Func<DalComment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetByTaskId(int taskId)
        {
            return _dbContext.Set<Comment>().Where(comment => comment.TodoTaskRefId == taskId)
               .Select(comment => comment.ToDalComment());
        }

        public void Update(DalComment entity)
        {
            
            var comment = _dbContext.Entry(entity);
            foreach (var property in comment.OriginalValues.PropertyNames)//comment.GetType().GetTypeInfo().DeclaredProperties
            {
                var original = comment.Property(property).OriginalValue;
                var current = comment.Property(property).CurrentValue;
                if (original != null && !original.Equals(current))
                    comment.Property(property).IsModified = true;
            }
        }
    }
}
