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
        }

        public IEnumerable<UserProfile> GetAll()
        {
            var users = _dbContext.Set<UserProfileDbModel>().ToList();
            var mappedUsers = users.Select(u => Mapper.DynamicMap<UserProfileDbModel, UserProfile>(u));
            return mappedUsers;
        }

        public UserProfile GetById(int key)
        {
            var user = _dbContext.Set<UserProfileDbModel>().FirstOrDefault(u => u.Id == key);
            var mappedUserProfile = Mapper.DynamicMap<UserProfileDbModel, UserProfile>(user);
            if (mappedUserProfile != null)
            {
                mappedUserProfile.UserName = user?.Name;
            }
            return mappedUserProfile;
        }

        public UserProfile GetByPredicate(Expression<Func<UserProfile, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int Create(UserProfile entity)
        {
            UserProfileDbModel user = Mapper.DynamicMap<UserProfile, UserProfileDbModel>(entity);
            if (user != null)
            {
                user.Name = entity.UserName;
                _dbContext.Set<UserProfileDbModel>().Add(user);
                _dbContext.SaveChanges();
                return user.Id;
            }
            return 0;
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
            existedUser.Entity.Name = entity.UserName;
            existedUser.Entity.Avatar = entity.Avatar;
        }

        public void Delete(UserProfile entity)
        {
            var user = _dbContext.Set<UserProfileDbModel>().Single(u => u.Id == entity.Id);
            _dbContext.Set<UserProfileDbModel>().Remove(user);
        }

        public UserProfile GetUserProfileByEmail(string email)
        {
            var user = _dbContext.Set<UserProfileDbModel>().FirstOrDefault(u => u.Email == email);
            var mappedUserProfile = Mapper.DynamicMap<UserProfileDbModel, UserProfile>(user);
            if (mappedUserProfile != null)
            {
                mappedUserProfile.UserName = user?.Name;
            }
            return mappedUserProfile;
        }
    }
}
