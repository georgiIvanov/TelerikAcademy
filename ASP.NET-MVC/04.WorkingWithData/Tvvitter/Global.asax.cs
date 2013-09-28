using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tvvitter.Data;
using Tvvitter.Migrations;

namespace Tvvitter
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<TvvitterContext>(new CreateDatabaseIfNotExists<TvvitterContext>());


            Database.SetInitializer<TvvitterContext>(
                new MigrateDatabaseToLatestVersion<TvvitterContext, Configuration>());

        }
    }
}
