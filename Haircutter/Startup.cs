using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Haircutter.Startup))]
namespace Haircutter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
