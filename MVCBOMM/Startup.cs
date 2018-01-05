using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBOMM.Startup))]
namespace MVCBOMM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
