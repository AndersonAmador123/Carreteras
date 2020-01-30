using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Carreteras.Startup))]
namespace Carreteras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
