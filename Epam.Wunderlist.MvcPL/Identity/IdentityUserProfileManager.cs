using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Epam.Wunderlist.DataAccess.Entities;
using Epam.Wunderlist.DataServices.UserProfileServices;
using Epam.Wunderlist.MvcPL.Convertor;
using Microsoft.AspNet.Identity;

namespace Epam.Wunderlist.MvcPL.Identity
{
    public class IdentityUserProfileManager : UserManager<UserProfile, int>
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
                    return user;
                }
                return null;
            });
            return taskInvoke;
        }

        public override Task<ClaimsIdentity> CreateIdentityAsync(UserProfile user, string authenticationType)
        {
            ClaimsIdentity claim = new ClaimsIdentity(authenticationType, 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName, ClaimValueTypes.String));
            claim.AddClaim(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String));
            //claim.AddClaim(new Claim("Avatar", Convert.ToBase64String(user.Avatar.ImageToByteArray()), ClaimValueTypes.String));
            claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                "OWIN Provider", ClaimValueTypes.String));
            return Task.FromResult(claim);
        }
    }
}