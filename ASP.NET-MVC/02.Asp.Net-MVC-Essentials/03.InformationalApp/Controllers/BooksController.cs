using _03.InformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03.InformationalApp.Controllers
{
    public class BooksController : Controller
    {
        public BooksController()
        {
            this.Books = BooksDataSource.Books;
        }
        List<Book> Books { get; set; }
        //
        // GET: /Books/
        public ActionResult Index()
        {
           
            
            return View("Books", Books);
        }

        public ActionResult GetBook(int Id)
        {

            return View("Book", Books[Id]);
        }
	}
}