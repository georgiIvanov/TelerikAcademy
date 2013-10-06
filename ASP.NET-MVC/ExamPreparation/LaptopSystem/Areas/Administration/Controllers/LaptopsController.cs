using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Models;
using LaptopSystem.Data;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LaptopSystem.Areas.Administration.Models;


namespace LaptopSystem.Areas.Administration.Controllers
{
    [Authorize]
    public class LaptopsController : Controller
    {
        private IUoWLaptopData db;

        public LaptopsController(IUoWLaptopData db)
        {
            this.db = db;
        }

        // GET: /Administration/Laptops/
        public ActionResult Index()
        {
            var laptops = db.Laptops.All().ToList();

            foreach (var item in laptops)
            {
                if (item.Image.Length > 20)
                {
                    item.Image = item.Image.Substring(0, 20);
                }
                else if (item.Model.Length > 20)
                {
                    item.Model = item.Model.Substring(0, 20);
                }
            }

            return View(laptops);
        }

        // GET: /Administration/Laptops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.GetById((int)id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // GET: /Administration/Laptops/Create
        public ActionResult Create()
        {
            LaptopCreateViewModel vm = new LaptopCreateViewModel
            {
                Manufacturers = db.Manufacturers.All().ToList()
            };
            return View(vm);
        }

        // POST: /Administration/Laptops/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LaptopCreateViewModel postedLaptop, string manufacturer)
        {
            if (ModelState.IsValid)
            {
                var laptop = postedLaptop.Laptop;
                laptop.Manufacturer = db.Manufacturers.All().Single(x => x.Name == manufacturer);


                db.Laptops.Add(laptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            postedLaptop.Manufacturers = db.Manufacturers.All().ToList();

            return View(postedLaptop);
        }

        // GET: /Administration/Laptops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.GetById((int)id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: /Administration/Laptops/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                db.Laptops.Update(laptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laptop);
        }

        // GET: /Administration/Laptops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laptop laptop = db.Laptops.GetById((int)id);
            if (laptop == null)
            {
                return HttpNotFound();
            }
            return View(laptop);
        }

        // POST: /Administration/Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laptop laptop = db.Laptops.GetById(id);

            if (laptop == null)
            {
                return HttpNotFound();
            }

            var comments = laptop.Comments.ToList();
            foreach (var comment in comments)
            {
                db.Comments.Delete(comment);
            }
            db.SaveChanges();

            var votes = laptop.Votes.ToList();
            foreach (var vote in votes)
            {
                db.Votes.Delete(vote);
            }
            db.SaveChanges();


            db.Laptops.Delete(laptop);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
