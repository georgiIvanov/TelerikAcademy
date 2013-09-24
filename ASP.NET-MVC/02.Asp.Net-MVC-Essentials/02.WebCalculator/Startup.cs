using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.WebCalculator.Startup))]
namespace _02.WebCalculator
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
