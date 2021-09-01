using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homiee.Startup))]
namespace Homiee
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
