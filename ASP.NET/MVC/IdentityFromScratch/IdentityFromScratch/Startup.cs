using IdentityFromScratch.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityFromScratch.Startup))]
namespace IdentityFromScratch
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);

            app.CreatePerOwinContext<ApplicationUserManager>
                (ApplicationUserManager.Create);

            app.CreatePerOwinContext<ApplicationSignInManager>
                (ApplicationSignInManager.Create);
        }
    }
}