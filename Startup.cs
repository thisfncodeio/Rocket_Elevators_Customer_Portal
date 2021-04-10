using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rocket_Elevators_Customer_Portal.Startup))]
namespace Rocket_Elevators_Customer_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
