using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Concesionarios.UI.Web.Startup))]
namespace Concesionarios.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
