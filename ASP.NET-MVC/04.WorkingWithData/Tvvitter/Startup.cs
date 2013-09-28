using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tvvitter.Startup))]
namespace Tvvitter
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
