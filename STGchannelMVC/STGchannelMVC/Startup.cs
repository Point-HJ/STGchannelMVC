using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(STGchannelMVC.Startup))]
namespace STGchannelMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
