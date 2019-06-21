using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventHandlingApp.Startup))]
namespace EventHandlingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
