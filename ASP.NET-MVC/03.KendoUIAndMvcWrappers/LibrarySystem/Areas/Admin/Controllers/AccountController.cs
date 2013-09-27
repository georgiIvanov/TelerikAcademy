using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}