using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.UserProfileServices;
using Microsoft.AspNet.Identity;

namespace Epam.Wunderlist.MvcPL.Identity
{
    public class IdentityUserProfileManager : UserManager<UserProfile>
    {
        private IUserProfileService UserProfileService =>
            (IUserProfileService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserProfileService));

        public IdentityUserProfileManager() : base(new IdentityUserStore())
        {
        }

        //public static IdentityUserProfileManager Create()
        //{
        //    IdentityUserProfileManager manager = new IdentityUserProfileManager();
        //    return manager;
        //}

        public override Task<UserProfile> FindAsync(string userName, string password)
        {
            Task<UserProfile> taskInvoke = Task<UserProfile>.Factory.StartNew(() =>
            {
                var user = UserProfileService.GetByEmail(userName);
                if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                {
                    user.UserName = user.Email;
                    return user;
                }
                return null;
            });
            return taskInvoke;
        }

        //public override Task<ClaimsIdentity> CreateIdentityAsync(UserProfile user, string authenticationType)
        //{
        //    var identity = new ClaimsIdentity();
        //    identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        //    return Task.FromResult(identity);
        //}
    }
}