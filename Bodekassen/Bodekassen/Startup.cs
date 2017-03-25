using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bodekassen.Startup))]
namespace Bodekassen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
