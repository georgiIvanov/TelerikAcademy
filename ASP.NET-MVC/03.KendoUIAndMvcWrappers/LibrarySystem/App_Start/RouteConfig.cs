using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibrarySystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Area",
                url: "Admin/{controller}/{action}/{id}",
                namespaces: new string[] { "LibrarySystem.Areas.Admin.Controllers" },
                defaults: new { }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                namespaces: new string[] { "LibrarySystem.Controllers" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
