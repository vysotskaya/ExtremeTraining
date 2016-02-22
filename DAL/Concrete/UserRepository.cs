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
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _dbContext.Set<User>().Select(u => new DalUser()
            {
                Name = u.Name,
                Id = u.Id,
                Email = u.Email,
                Password = u.Password,
                Photo = u.Photo
            });
        }

        public DalUser GetById(int key)
        {
            var user = _dbContext.Set<User>().FirstOrDefault(u => u.Id == key);
            return user?.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser entity)
        {
            var user = entity.ToUser();
            _dbContext.Set<User>().Add(user);
        }

        public void Update(DalUser entity)
        {
            var updatedUser = entity.ToUser();
            var existedUser = _dbContext.Entry<User>(_dbContext.Set<User>().Find(updatedUser.Id));
            if (existedUser == null)
            {
                return;
            }
            existedUser.State = EntityState.Modified;
            existedUser.Entity.Name = entity.Name;
            existedUser.Entity.Email = entity.Email;
            existedUser.Entity.Password = entity.Password;
            existedUser.Entity.Photo = entity.Photo;
            existedUser.Collection(l => l.TodoLists).Load();
            existedUser.Entity.TodoLists.Clear();
            foreach (TodoList todoList in updatedUser.TodoLists)
            {
                var loaded = _dbContext.Set<TodoList>().Find(todoList.Id);
                existedUser.Entity.TodoLists.Add(loaded);
            }
        }

        public void Delete(DalUser entity)
        {
            var user = _dbContext.Set<User>().Single(u => u.Id == entity.Id);
            _dbContext.Set<User>().Remove(user);
        }
    }
}
