using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataAccess.Interfaces.Repositories;
using Epam.Wunderlist.DataAccess.MSSql.Convertor;
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
                cfg.CreateMap<UserProfileDbModel, UserProfile>()
                    .ForMember(x => x.Avatar, y => y.MapFrom(s => s.Avatar.ByteArrayToImage()));
                cfg.CreateMap<UserProfile, UserProfileDbModel>()
                    .ForSourceMember(x => x.Id, y => y.Ignore())
                    .ForMember(x => x.Avatar, y => y.MapFrom(s => s.Avatar.ImageToByteArray()));
            });
        }

        public IEnumerable<UserProfile> GetAll()
        {
            var users = _dbContext.Set<UserProfileDbModel>().ToList();
            var mappedUsers = users.Select(u => Mapper.Map<UserProfileDbModel, UserProfile>(u));
            return mappedUsers;
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

        public bool Create(UserProfile entity)
        {
            var user = Mapper.Map<UserProfile, UserProfileDbModel>(entity);
            return _dbContext.Set<UserProfileDbModel>().Add(user) != null;
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
