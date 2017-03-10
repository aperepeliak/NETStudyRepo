using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OWINKatana.Startup))]
namespace OWINKatana
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
