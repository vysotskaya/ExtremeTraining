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
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly DbContext _dbContext;

        public UserProfileRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Mapper.Initialize(cfg => {
                cfg.CreateMap<UserProfileDbModel, UserProfile>();
                cfg.CreateMap<UserProfile, UserProfileDbModel>()
                    .ForSourceMember(x => x.Id, y => y.Ignore());
            });
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _dbContext.Set<UserProfileDbModel>().ToList()
                .Select(u => Mapper.Map<UserProfileDbModel, UserProfile>(u));
        }

        public UserProfile GetById(int key)
        {
            var user = _dbContext.Set<UserProfileDbModel>().FirstOrDefault(u => u.Id == key);
            return Mapper.Map<UserProfileDbModel, UserProfile>(user);
        }

        public UserProfile GetByPredicate(Expression<Func<UserProfile, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Create(UserProfile entity)
        {
            var user = Mapper.Map<UserProfile, UserProfileDbModel>(entity);
            _dbContext.Set<UserProfileDbModel>().Add(user);
        }

        public void Update(UserProfile entity)
        {
            var updatedUser = Mapper.Map<UserProfile, UserProfileDbModel>(entity);
            var existedUser = _dbContext.Entry<UserProfileDbModel>
                (
                    _dbContext.Set<UserProfileDbModel>().Find(updatedUser.Id)
                );
            if (existedUser == null)
            {
                return;
            }
            existedUser.State = EntityState.Modified;
            existedUser.Entity.Name = entity.Name;
            existedUser.Entity.Email = entity.Email;
            existedUser.Entity.Password = entity.Password;
        }

        public void Delete(UserProfile entity)
        {
            var user = _dbContext.Set<UserProfileDbModel>().Single(u => u.Id == entity.Id);
            _dbContext.Set<UserProfileDbModel>().Remove(user);
        }
    }
}
