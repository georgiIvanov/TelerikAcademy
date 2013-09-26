using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Areas.Admin.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        //
        // GET: /Admin/Books/
        public ActionResult Index()
        {
            return View("Books");
        }
	}
}