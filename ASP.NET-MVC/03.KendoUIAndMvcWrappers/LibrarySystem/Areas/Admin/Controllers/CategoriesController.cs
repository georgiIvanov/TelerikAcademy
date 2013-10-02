using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using System.Data.Entity;
using LibrarySystem.ViewModels;
using LibrarySystem.Utilities;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;


namespace LibrarySystem.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        //
        // GET: /Admin/Categories/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriesRead([DataSourceRequest]DataSourceRequest request)
        {
            var db = new LibraryDbContext();
            IQueryable<Category> found = db.Categories;

            var viewModelCategories = found.ConvertToCategoryViewModel().ToList();


            DataSourceResult result = viewModelCategories.ToDataSourceResult(request);
            
            return Json(result);
        }

        public ActionResult CategoriesCreate([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();

                Category newCategory = new Category()
                {
                    Name = category.Name
                };

                newCategory.Id = db.Categories.Add(newCategory).Id;
                db.SaveChanges();
                category.Id = newCategory.Id;
            }
            
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CategoriesUpdate([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();

                var newCategory = new Category()
                {
                    Id = category.Id,
                    Name = category.Name
                };
                db.Categories.Attach(newCategory);
                db.Entry(newCategory).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CategoriesDelete([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var db = new LibraryDbContext();

                var toDelete = new Category()
                {
                    Id = category.Id,
                    Name = category.Name
                };

                db.Categories.Attach(toDelete);
                db.Categories.Remove(toDelete);
                db.SaveChanges();
            }
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
	}
}