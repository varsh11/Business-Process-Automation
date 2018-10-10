using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BPA_Varsh.Startup))]
namespace BPA_Varsh
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
