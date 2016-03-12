using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DataAccess.MSSqlDbModel;

namespace Epam.Wunderlist.DataAccess.MSSql.Concrete
{
    public class TodoSubtaskRepository : ITodoSubtaskRepository
    {
        private readonly DbContext _dbContext;

        public TodoSubtaskRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TodoSubtaskDbModel, TodoSubtask>();
                cfg.CreateMap<TodoSubtask, TodoSubtaskDbModel>()
                    .ForSourceMember(x => x.Id, y => y.Ignore());
            });
        }

        public int Create(TodoSubtask entity)
        {
            var todoSubtask = Mapper.Map<TodoSubtask, TodoSubtaskDbModel>(entity);
            _dbContext.Set<TodoSubtaskDbModel>().Add(todoSubtask);
            _dbContext.SaveChanges();
            return  todoSubtask.Id;
        }

        public void Delete(TodoSubtask entity)
        {
            var removeSubtask = _dbContext.Set<TodoSubtaskDbModel>().FirstOrDefault(subtask => subtask.Id == entity.Id);
            if (removeSubtask != null)
            {
                _dbContext.Set<TodoSubtaskDbModel>().Remove(removeSubtask);
            }
        }

        public IEnumerable<TodoSubtask> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoSubtask GetById(int key)
        {
            var subtask = _dbContext.Set<TodoSubtaskDbModel>().FirstOrDefault(st => st.Id == key);
            return Mapper.Map<TodoSubtaskDbModel, TodoSubtask>(subtask);
        }

        public TodoSubtask GetByPredicate(Expression<Func<TodoSubtask, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoSubtask> GetByTaskId(int taskId)
        {
            return _dbContext.Set<TodoSubtaskDbModel>().Where(subtask => subtask.TodoTaskRefId == taskId)
                .Select(subtask => Mapper.Map<TodoSubtaskDbModel, TodoSubtask>(subtask));
        }

        public void Update(TodoSubtask entity)
        {

            var subtask = _dbContext.Entry(Mapper.Map<TodoSubtask, TodoSubtaskDbModel>(entity));
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
