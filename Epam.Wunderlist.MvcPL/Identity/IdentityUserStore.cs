using System;
using System.Threading.Tasks;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.UserProfileServices;
using Microsoft.AspNet.Identity;

namespace Epam.Wunderlist.MvcPL.Identity
{
    public class IdentityUserStore : IUserStore<UserProfile>, IUserPasswordStore<UserProfile>
    {
        private IUserProfileService UserProfileService => 
            (IUserProfileService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof (IUserProfileService));

        public Task<UserProfile> FindByNameAsync(string email)
        {
            UserProfile user = UserProfileService.GetByEmail(email);
            return Task.FromResult<UserProfile>(user);
        }
        public Task CreateAsync(UserProfile user)
        {
            return Task.FromResult<bool>(UserProfileService.Create(user));
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
        public System.Threading.Tasks.Task DeleteAsync(UserProfile user)
        {
            throw new NotImplementedException();
        }
        public System.Threading.Tasks.Task<UserProfile> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
        public System.Threading.Tasks.Task UpdateAsync(UserProfile user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> HasPasswordAsync(UserProfile user)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}