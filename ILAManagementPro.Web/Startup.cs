using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ILAManagementPro.Web.Startup))]
namespace ILAManagementPro.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
