using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_03.InformationalApp.Startup))]
namespace _03.InformationalApp
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
