using LaptopSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Areas.Administration.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LaptopSystem.Models;

namespace LaptopSystem.Areas.Administration.Controllers
{
    public class CommentsController : Controller
    {
        private IUoWLaptopData db;

        public CommentsController(IUoWLaptopData db)
        {
            this.db = db;
        }
        //
        // GET: /Administration/Comments/
        public ActionResult Index()
        {
            //var comments = db.Comments.All("User", "Laptop").ToList();

            //return View(comments.ToViewModel());
            return View();
        }

        public ActionResult CommentsRead([DataSourceRequest]DataSourceRequest request)
        {

            IQueryable<Comment> found = db.Comments.All("User", "Laptop");

            var viewModelComments = found.ToList().ToViewModel();


            DataSourceResult result = viewModelComments.ToDataSourceResult(request);

            return Json(result);
        }

        public ActionResult CommentsUpdate([DataSourceRequest]DataSourceRequest request, CommentsViewModel commentVm)
        {
            if (ModelState.IsValid)
            {
                

                var comment = db.Comments.All("User", "Laptop").Single(x => x.Id == commentVm.Id);

                if (comment.User.UserName != commentVm.ByUser)
                {
                    var user = db.Users.All().FirstOrDefault(x => x.UserName == commentVm.ByUser);
                    comment.User = user;
                    comment.Content = commentVm.Content;

                    //UpdateBookFields(book, oldBook);
                    //user.Books.Add(oldBook);
                    //db.Comments.Update(comment);
                    db.SaveChanges();
                }
                if (comment.Laptop == null || comment.Laptop.Model != commentVm.OnLaptop)
                {
                    var laptop = db.Laptops.All().FirstOrDefault(x => x.Model == commentVm.OnLaptop);
                    if (laptop != null)
                    {
                        comment.Laptop = laptop;
                        
                    }
                }
                //UpdateBookFields(book, oldBook);
                comment.Content = commentVm.Content;

                db.Comments.Update(comment);
                db.SaveChanges();

            }
            return Json(new[] { commentVm }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult CommentsDelete([DataSourceRequest]DataSourceRequest request, CommentsViewModel commentVm)
        {

            if (ModelState.IsValid)
            {
                var comment = db.Comments.GetById(commentVm.Id);
                db.Comments.Delete(comment);
                db.SaveChanges();
            }
            return Json(new[] { commentVm }.ToDataSourceResult(request, ModelState));
        }


    }
}