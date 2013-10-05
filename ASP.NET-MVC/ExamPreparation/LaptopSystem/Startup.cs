using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaptopSystem.Startup))]
namespace LaptopSystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
