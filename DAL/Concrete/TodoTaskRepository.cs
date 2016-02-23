using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface.DalEntities;
using DAL.Interface.Repositories;
using DAL.Mappers;
using ORM;

namespace DAL.Concrete
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly DbContext _dbContext;

        public TodoTaskRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DalTodoTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalTodoTask GetById(int key)
        {
            var todoTask = _dbContext.Set<TodoTask>().FirstOrDefault(t => t.Id == key);
            return todoTask?.ToDalTodoTask();
        }

        public DalTodoTask GetByPredicate(Expression<Func<DalTodoTask, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Create(DalTodoTask entity)
        {
            var todoTask = entity.ToTodoTask();
            _dbContext.Set<TodoTask>().Add(todoTask);
        }

        public void Update(DalTodoTask entity)
        {
            var updatedTodoTask = entity.ToTodoTask();
            var existedTodoTask = _dbContext.Entry<TodoTask>(_dbContext.Set<TodoTask>().Find(updatedTodoTask.Id));
            if (existedTodoTask == null)
            {
                return;
            }
            existedTodoTask.State = EntityState.Modified;
            existedTodoTask.Entity.Name = entity.Name;
            existedTodoTask.Entity.Note = entity.Note;
            existedTodoTask.Entity.StateRefId = entity.StateRefId;
        }

        public void Delete(DalTodoTask entity)
        {
            var todoTask = _dbContext.Set<TodoTask>().Single(t => t.Id == entity.Id);
            _dbContext.Set<TodoTask>().Remove(todoTask);
        }

        public ICollection<DalTodoTask> GetByTodoListId(int listId)
        {
            return _dbContext.Set<TodoTask>()
                .Where(t => t.TodoListRefId == listId)
                .Select(t => new DalTodoTask()
                {
                    Id = t.Id,
                    Name = t.Name,
                    StateRefId = t.StateRefId,
                    TodoListRefId = t.TodoListRefId,
                    Note = t.Note,
                    CreationDate = t.CreationDate
                }).ToList();
        }
    }
}
