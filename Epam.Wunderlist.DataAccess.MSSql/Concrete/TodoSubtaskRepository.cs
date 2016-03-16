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
        }

        public int Create(TodoSubtask entity)
        {
            var todoSubtask = Mapper.DynamicMap<TodoSubtask, TodoSubtaskDbModel>(entity);
            _dbContext.Set<TodoSubtaskDbModel>().Add(todoSubtask);
            _dbContext.SaveChanges();
            return todoSubtask.Id;
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
            return Mapper.DynamicMap<TodoSubtaskDbModel, TodoSubtask>(subtask);
        }

        public TodoSubtask GetByPredicate(Expression<Func<TodoSubtask, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ICollection<TodoSubtask> GetByTaskId(int taskId)
        {
            return _dbContext.Set<TodoSubtaskDbModel>()
                .Where(subtask => subtask.TodoTaskRefId == taskId).ToList()
                .Select(subtask => Mapper.DynamicMap<TodoSubtaskDbModel, TodoSubtask>(subtask)).ToList();
        }

        public void Update(TodoSubtask entity)
        {

            var existedSubtask = _dbContext.Entry<TodoSubtaskDbModel>
                (
                    _dbContext.Set<TodoSubtaskDbModel>().Find(entity.Id)
                );
            if (existedSubtask == null)
            {
                return;
            }
            existedSubtask.State = EntityState.Modified;
            existedSubtask.Entity.TodoSubtaskName = entity.TodoSubtaskName;
            existedSubtask.Entity.TodoTaskRefId = entity.TodoTaskRefId;
            existedSubtask.Entity.TaskStateRefId = entity.TaskStateRefId;
        }
    }
}
