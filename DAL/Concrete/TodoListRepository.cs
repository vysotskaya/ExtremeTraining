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
    public class TodoListRepository : ITodoListRepository
    {
        private readonly DbContext _dbContext;

        public TodoListRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DalTodoList> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalTodoList GetById(int key)
        {
            var todoList = _dbContext.Set<TodoList>().FirstOrDefault(l => l.Id == key);
            return todoList?.ToDalTodoList();
        }

        public DalTodoList GetByPredicate(Expression<Func<DalTodoList, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Create(DalTodoList entity)
        {
            var todoList = entity.ToTodoList();
            _dbContext.Set<TodoList>().Add(todoList);
        }

        public void Update(DalTodoList entity)
        {
            var updatedTodoList = entity.ToTodoList();
            var existedTodoList = _dbContext.Entry<TodoList>(_dbContext.Set<TodoList>().Find(updatedTodoList.Id));
            if (existedTodoList == null)
            {
                return;
            }
            existedTodoList.State = EntityState.Modified;
            existedTodoList.Entity.Name = entity.Name;
            //share list
            existedTodoList.Collection(l => l.Users).Load();
            existedTodoList.Entity.Users.Clear();
            foreach (User user in updatedTodoList.Users)
            {
                var loaded = _dbContext.Set<User>().Find(user.Id);
                existedTodoList.Entity.Users.Add(loaded);
            }
            //another properties
        }

        public void Delete(DalTodoList entity)
        {
            var todoList = _dbContext.Set<TodoList>().Single(l => l.Id == entity.Id);
            _dbContext.Set<TodoList>().Remove(todoList);
        }

        public ICollection<DalTodoList> GetByUserId(int userId)
        {
            return _dbContext.Set<TodoList>()
                .Where(t => t.Users.Any(u => u.Id == userId))
                .Select(t => new DalTodoList()
                {
                    Name = t.Name,
                    Id = t.Id
                }).ToList();
        }
    }
}
