using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesApp.Startup))]
namespace MoviesApp
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
