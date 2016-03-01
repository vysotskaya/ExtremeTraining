using Epam.Wunderlist.DataAccess.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Epam.Wunderlist.MvcPL.Identity
{
    public class IdentityUserProfileManager : UserManager<UserProfile>
    {
        public IdentityUserProfileManager(IUserStore<UserProfile> store) : base(store)
        {
        }

        public static IdentityUserProfileManager Create(IdentityFactoryOptions<IdentityUserProfileManager> options,
                                            IOwinContext context)
        {
            IdentityUserProfileManager manager = new IdentityUserProfileManager(new UserStore<UserProfile>());
            return manager;
        }
    }
}