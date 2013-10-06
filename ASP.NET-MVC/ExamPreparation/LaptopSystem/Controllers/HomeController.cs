using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LaptopSystem.Data;
using LaptopSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Models;
using System.IO;

namespace LaptopSystem.Controllers
{
    public class HomeController : Controller
    {
        IUoWLaptopData db;
        public HomeController(IUoWLaptopData db)
        {
            this.db = db;
        }

        [OutputCache(Duration=3600)]
        public ActionResult Index()
        {
            var topLaptops = db.Laptops.All("Manufacturer").OrderByDescending(x => x.Votes.Count).Take(6).ToList();

            HomeIndexViewModel vm = new HomeIndexViewModel();
            vm.Laptops = topLaptops.ToViewModel();

            return View(vm);
        }

        public ActionResult ViewDetails(int id)
        {
            var found = db.Laptops.All("Votes").Single(x => x.Id == id);

            var comments = db.Comments.All("User", "Laptop")
                            .Where(x => x.Laptop.Id == found.Id)
                            .ToList().ToViewModel();
            var result = found.ToViewModel(true);
            result.Comments = comments;

            return View(result);
        }

        [Authorize]
        [HttpPost]
        public ActionResult PostComment(PostComment postedComment)
        {
            var laptop = db.Laptops.GetById(postedComment.LaptopId);
            var user = db.Users.All().Single(x => x.UserName == User.Identity.Name);


            Comment comment = new Comment
            {
                Content = postedComment.Content,
                Laptop = laptop,
                User = user
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            var comments = db.Comments.All("User", "Laptop")
                .Where(x => x.Laptop.Id == postedComment.LaptopId)
                .ToList().ToViewModel();

            //string renderHtml = RenderPartialViewToString("_Comments", comments);

            return PartialView("_Comments", comments);
            //return renderHtml;
        }

        [Authorize]
        [HttpPost]
        public string VoteForLaptop(int laptopId)
        {
            var user = db.Users.All().Single(x => x.UserName == User.Identity.Name);

            var existingVote = db.Votes.All("User", "Laptop")
                .Where(x => x.User.UserName == user.UserName
                && x.Laptop.Id == laptopId).FirstOrDefault();

             var laptop = db.Laptops.GetById(laptopId);

            if (existingVote == null)
            {
               
                laptop.Votes.Add(new Vote
                {
                    Laptop = laptop,
                    User = user
                });
                db.SaveChanges();

                return laptop.Votes.Count.ToString();
            }
            else
            {
                return string.Format("{0}, you have already voted for this laptop", laptop.Votes.Count.ToString());
            }
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }

        [Authorize]
        public ActionResult ListPage()
        {
            var allLaptops = db.Laptops.All("Manufacturer").ToList();

            var allManufacturers = db.Manufacturers.All().ToList();

            ListPageViewModel vm = new ListPageViewModel()
            {
                Laptops = allLaptops.ToViewModel(),
                Manufacturers = allManufacturers,
                IsSearch = false
            };

            return View(vm);
        }

        public ActionResult LaptopsRead([DataSourceRequest] DataSourceRequest request)
        {
            var laptops = db.Laptops.All("Manufacturer").ToList().ToViewModel();

            DataSourceResult result = laptops.ToDataSourceResult(request);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Search(string modelInput, string manufacturerInput, decimal? priceInput)
        {
            var laptops = db.Laptops.All("Manufacturer");

            if (!string.IsNullOrWhiteSpace(modelInput))
            {
                laptops = laptops.Where(x => x.Model.ToLower().Contains(modelInput.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(manufacturerInput))
            {
                laptops = laptops.Where(x => x.Manufacturer.Name == manufacturerInput);
            }

            if (priceInput != null)
            {
                laptops = laptops.Where(x => x.Price == priceInput);
            }

            var found = laptops.ToList().ToViewModel();

            return PartialView("_SearchResult", found);
        }

        public JsonResult GetLaptopModels(string text)
        {
            var laptops = db.Laptops.All().Where(x => x.Model.ToLower().Contains( text.ToLower())).ToList().ToViewModel();

            return Json(laptops, JsonRequestBehavior.AllowGet);
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