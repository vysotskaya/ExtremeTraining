using System;
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
        private readonly DbContext context;

        public void Create(DalComment entity)
        {
            var comment = entity?.ToComment();
            context.Set<Comment>().Add(comment);
        }

        public void Delete(DalComment entity)
        {
            if (context.Set<Comment>().Any(comment => comment.Id == entity.Id))
            {
                var comment = entity.ToComment();
                context.Set<Comment>().Remove(comment);
            }
        }

        public IEnumerable<DalComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalComment GetById(int key)
        {
            return context.Set<Comment>().FirstOrDefault(comment => comment.Id == key)?.ToDalComment();
        }

        public DalComment GetByPredicate(Expression<Func<DalComment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalComment> GetByTaskId(int taskId)
        {
            return context.Set<Comment>().Where(comment => comment.TodoTaskRefId == taskId)
               .Select(comment => comment.ToDalComment());
        }

        public void Update(DalComment entity)
        {
            
            var comment = context.Entry(entity);
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
