using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sherlock.Startup))]
namespace Sherlock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
