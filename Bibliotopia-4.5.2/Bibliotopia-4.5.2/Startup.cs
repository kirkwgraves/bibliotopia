using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bibliotopia_4._5._2.Startup))]
namespace Bibliotopia_4._5._2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
