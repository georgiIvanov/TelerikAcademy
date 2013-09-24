using _03.InformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.InformationalApp.Areas.AdminArea.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /AdminArea/Admin/
        public ActionResult Index()
        {
            return View("ControlPanelView");
        }

        [HttpPost]
        public ActionResult Index(Book model)
        {
            if (ModelState.IsValid)
            {
                BooksDataSource.Books.Add(new Book()
                {
                    Name = model.Name,
                    Author = model.Author,
                    Description = model.Description,
                    Rating = Convert.ToDouble(model.Rating)
                });

                Response.Redirect("/Books");
            }

            return View("ControlPanelView");
        }
	}
}