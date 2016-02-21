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
    public class TodoSubtaskRepository : ITodoSubtaskRepository
    {
        private readonly DbContext context;

        public void Create(DalTodoSubtask entity)
        {
            var todoSubtask = entity.ToTodoSubtask();
            context.Set<TodoSubtask>().Add(todoSubtask);
        }

        public void Delete(DalTodoSubtask entity)
        {
            if (context.Set<TodoSubtask>().Any(subtask => subtask.Id == entity.Id))
            {
                var todoSubtask = entity.ToTodoSubtask();
                context.Set<TodoSubtask>().Remove(todoSubtask);
            }          
        }

        public IEnumerable<DalTodoSubtask> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalTodoSubtask GetById(int key)
        {
            return context.Set<TodoSubtask>().FirstOrDefault(subtask => subtask.Id == key)?.ToDalTodoSubtask();
        }

        public DalTodoSubtask GetByPredicate(Expression<Func<DalTodoSubtask, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTodoSubtask> GetBySate(int stateId)
        {
            return context.Set<TodoSubtask>().Where(subtask => subtask.StateRefId == stateId)
                .Select(subrask => subrask.ToDalTodoSubtask());
        }

        public IEnumerable<DalTodoSubtask> GetByTaskId(int taskId)
        {
            return context.Set<TodoSubtask>().Where(subtask => subtask.TodoTaskRefId == taskId)
                .Select(subtask => subtask.ToDalTodoSubtask());
        }

        public void Update(DalTodoSubtask entity)
        {
            //if (context.Set<TodoSubtask>().Any(subtask => subtask.Id == entity.Id))
            //{
            //    var updateEntity = entity.ToTodoSubtask();
            //    context.Entry(updateEntity).State = EntityState.Modified;
            //}
            var subtask = context.Entry(entity);
            foreach (var property in subtask.OriginalValues.PropertyNames)//subtask.GetType().GetTypeInfo().DeclaredProperties
            {
                var original = subtask.Property(property).OriginalValue;
                var current = subtask.Property(property).CurrentValue;
                if (original != null && !original.Equals(current))
                    subtask.Property(property).IsModified = true;
            }
        }
    }
}
