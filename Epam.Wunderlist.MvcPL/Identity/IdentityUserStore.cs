using System;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.UserProfileServices;
using Microsoft.AspNet.Identity;

namespace Epam.Wunderlist.MvcPL.Identity
{
    public class IdentityUserStore : IUserStore<UserProfile, int>, IUserPasswordStore<UserProfile, int>
    {
        private IUserProfileService UserProfileService => 
            (IUserProfileService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IUserProfileService));

        public Task<UserProfile> FindByIdAsync(int userId)
        {
            UserProfile user = UserProfileService.GetById(userId);
            return Task.FromResult<UserProfile>(user);
        }

        public Task<UserProfile> FindByNameAsync(string email)
        {
            UserProfile user = UserProfileService.GetByEmail(email);
            return Task.FromResult<UserProfile>(user);
        }
        public Task CreateAsync(UserProfile user)
        {
            var userProfileId = UserProfileService.Create(user);
            user.Id = userProfileId;
            return Task.FromResult<bool>(userProfileId == 0);
        }
        public Task<string> GetPasswordHashAsync(UserProfile user)
        {
            return Task.FromResult<string>(user.Password);
        }
        public Task SetPasswordHashAsync(UserProfile user, string passwordHash)
        {
            return Task.FromResult<string>(user.Password = passwordHash);
        }

        #region Not implemented methods     
        public Task DeleteAsync(UserProfile user)
        {
            throw new NotImplementedException();
        }
        public Task<UserProfile> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(UserProfile user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> HasPasswordAsync(UserProfile user)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        #endregion
    }
}