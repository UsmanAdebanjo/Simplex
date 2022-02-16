using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simplex.Startup))]
namespace Simplex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
