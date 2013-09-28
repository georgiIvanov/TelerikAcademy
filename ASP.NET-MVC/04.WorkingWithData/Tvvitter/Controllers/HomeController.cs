using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tvvitter.Data;

namespace Tvvitter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TvvitterContext db = new TvvitterContext();
            db.Tweets.ToList();
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