using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPGroupProject.Startup))]
namespace ASPGroupProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
