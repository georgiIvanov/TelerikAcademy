using CodeJewels.DataLayer;
using CodeJewels.Service.Resolvers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CodeJewels.DataLayer.Migrations;

namespace CodeJewels.Service
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        public void ConfigureDependencyResolver(HttpConfiguration config)
        {
            config.DependencyResolver = new DbDependencyResolver();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            this.ConfigureDependencyResolver(GlobalConfiguration.Configuration);

            Database.SetInitializer<CodeJewelsContext>(new MigrateDatabaseToLatestVersion<CodeJewelsContext, Configuration>());
            //Database.SetInitializer<CodeJewelsContext>(new DropCreateDatabaseIfModelChanges<CodeJewelsContext>());
            
        }
    }
}