using Epam.Wunderlist.MvcPL.App_Start;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Epam.Wunderlist.MvcPL.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext(IdentityUserProfileManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}