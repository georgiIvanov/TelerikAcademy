using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.InformationalApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.ViewData.Add("Username", this.User.Identity.Name);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}