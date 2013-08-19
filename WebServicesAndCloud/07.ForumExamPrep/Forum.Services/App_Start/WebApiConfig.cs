using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Forum.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "ThreadsApi",
                routeTemplate: "api/threads/{threadId}/posts",
                defaults: new
                {
                    controller = "threads",
                    action = "posts"
                }
            );

            config.Routes.MapHttpRoute(
               name: "UsersApi",
               routeTemplate: "api/users/{action}",
               defaults: new
               {
                   controller = "users"
               }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           // config.Routes.MapHttpRoute(
           //    name: "Search",
           //    routeTemplate: "api/{controller}/{query}",
           //    defaults: new { query = @"^[a-z]+$" }
           //);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
= Newtonsoft.Json.ReferenceLoopHandling.Ignore; 

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
