using _03.InformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _03.InformationalApp
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

            BooksDataSource.Books = new List<Book>()
            {
                new Book(){
                    Name = "C++ Essentials",
                    Author = "Kiro Motikata",
                    Description = "Hard practices to write selo code",
                    Rating = 10
                },
                new Book(){
                    Name = ".NET Essentials",
                    Author = "The Djibri brewing association",
                    Description = ".NET doesn't get better than this!",
                    Rating = 5.5
                },
                new Book(){
                    Name = "Moar buks",
                    Author = "The all knowing One",
                    Description = "N3ma",
                    Rating = 9.9
                },
                new Book(){
                    Name = "Lol",
                    Author = "The all knowing One",
                    Description = "dddddd dwad wa3",
                    Rating = 7.8
                }
            };
        }
    }
}
