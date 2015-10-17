using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CHorEG_v3.Startup))]
namespace CHorEG_v3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
