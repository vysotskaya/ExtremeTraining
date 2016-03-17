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
    public class TodoListRepository : ITodoListRepository
    {
        private readonly DbContext _dbContext;
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoListRepository(DbContext dbContext, ITodoTaskRepository todoTaskRepository)
        {
            _dbContext = dbContext;
            _todoTaskRepository = todoTaskRepository;
        }

        public IEnumerable<TodoList> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoList GetById(int key)
        {
            var todoList = _dbContext.Set<TodoListDbModel>().FirstOrDefault(l => l.Id == key);
            return Mapper.DynamicMap<TodoListDbModel, TodoList>(todoList);
        }

        public TodoList GetByPredicate(Expression<Func<TodoList, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int Create(TodoList entity)
        {
            var todoList = Mapper.DynamicMap<TodoList, TodoListDbModel>(entity);
            _dbContext.Set<TodoListDbModel>().Add(todoList);
            _dbContext.SaveChanges();
            return todoList.Id;
        }

        public void Update(TodoList entity)
        {
            var existedTodoList = _dbContext.Entry<TodoListDbModel>
                (
                    _dbContext.Set<TodoListDbModel>().Find(entity.Id)
                );
            if (existedTodoList == null)
            {
                return;
            }
            existedTodoList.State = EntityState.Modified;
            existedTodoList.Entity.TodoListName = entity.TodoListName;
        }

        public void Delete(TodoList entity)
        {
            var tasks = _todoTaskRepository.GetByTodoListId(entity.Id);
            foreach (var task in tasks)
            {
                var item = _todoTaskRepository.GetById(task.Id);
                _todoTaskRepository.Delete(item);
            }
            var todoList = _dbContext.Set<TodoListDbModel>().Single(l => l.Id == entity.Id);
            _dbContext.Set<TodoListDbModel>().Remove(todoList);
        }

        public ICollection<TodoList> GetByUserId(int userId)
        {
            var result = _dbContext.Set<TodoListDbModel>()
                .Where(l => l.UserProfileRefId == userId).ToList()
                .Select(l => Mapper.DynamicMap<TodoListDbModel, TodoList>(l)).ToList();
            return result;
        }
    }
}
