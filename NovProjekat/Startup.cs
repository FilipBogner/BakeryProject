using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NovProjekat.Startup))]
namespace NovProjekat
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
