using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Income.Web.Startup))]

namespace Income.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
