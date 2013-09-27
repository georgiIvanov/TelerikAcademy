using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystem.Models;
using System.Data.Entity;
using LibrarySystem.ViewModels;
using LibrarySystem.Utilities;

namespace LibrarySystem.Areas.Admin.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        //
        // GET: /Admin/Books/
        public ActionResult Index()
        {
            var db = new LibraryDbContext();
            var found = db.Books.ToList();
            return View(found);
            
        }

        public ActionResult BooksRead([DataSourceRequest]DataSourceRequest request)
        {
            var db = new LibraryDbContext();
            IQueryable<Book> found = db.Books;

            var viewModelBooks = found.ConvertToBookViewModel().ToList();

            foreach (var item in viewModelBooks)
            {
                if (item.Description != null && item.Description.Length > 20)
                {
                    item.Description = item.Description.Substring(0, 20);
                }
            }

            DataSourceResult result = viewModelBooks.ToDataSourceResult(request);
            
            return Json(result);
        }

        public ActionResult BooksCreate([DataSourceRequest]DataSourceRequest request, BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();

                Book newBook = new Book()
                {
                    Description = book.Description,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Website = book.Website
                };

                var category = db.Categories.FirstOrDefault(x => x.Name == book.CategoryName);
                category = CreateOrGetCategory(book, db, newBook, category);

                newBook.Id = db.Books.Add(newBook).Id;
                db.SaveChanges();
                book.Id = newBook.Id;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        private static Category CreateOrGetCategory(BookViewModel book, LibraryDbContext db, Book newBook, Category category)
        {
            if (category == null)
            {
                category = db.Categories.Add(new Category()
                {
                    Name = book.CategoryName
                });
                category.Books = new HashSet<Book>();
                category.Books.Add(newBook);
            }
            else
            {
                newBook.Category = category;
            }
            return category;
        }

        public ActionResult BooksUpdate([DataSourceRequest]DataSourceRequest request, BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();

                var category = db.Categories.FirstOrDefault(x => x.Name == book.CategoryName);

                var oldBook = db.Books.Single(x => x.Id == book.Id);
                
                if (oldBook.Category.Name != book.CategoryName)
                {
                    
                    oldBook.Category = category;
                    UpdateBookFields(book, oldBook);
                    category.Books.Add(oldBook);
                    
                    db.SaveChanges();
                }
                else
                {
                    UpdateBookFields(book, oldBook);
                    
                    db.Entry(oldBook).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        private static void UpdateBookFields(BookViewModel book, Book oldBook)
        {
            oldBook.Author = book.Author;
            oldBook.Description = book.Description;
            oldBook.ISBN = book.ISBN;
            oldBook.Title = book.Title;
            oldBook.Website = book.Website;
        }

        public ActionResult BooksDelete([DataSourceRequest]DataSourceRequest request, Book book)
        {
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();
                db.Books.Attach(book);
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }
    }
}