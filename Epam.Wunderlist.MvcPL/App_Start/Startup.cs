using Epam.Wunderlist.MvcPL.Identity;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Epam.Wunderlist.MvcPL.App_Start.Startup))]

namespace Epam.Wunderlist.MvcPL.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext<WunderlistIdentityDbContext>(WunderlistIdentityDbContext.Create);
            //app.CreatePerOwinContext<IdentityUserProfileManager>(IdentityUserProfileManager.Create);
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //});
        }
    }
}