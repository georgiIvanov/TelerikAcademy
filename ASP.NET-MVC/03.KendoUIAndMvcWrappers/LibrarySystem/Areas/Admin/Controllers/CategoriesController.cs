using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        //
        // GET: /Admin/Categories/
        public ActionResult Index()
        {
            return View("Categories");
        }
	}
}