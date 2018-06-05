using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CakeMaker.Startup))]
namespace CakeMaker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
