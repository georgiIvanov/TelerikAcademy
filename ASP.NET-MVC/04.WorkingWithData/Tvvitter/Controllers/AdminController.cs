using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tvvitter.Models;
using Tvvitter.Data;
using Tvvitter.Utility;
using Tvvitter.ViewModels;

namespace Tvvitter.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : BaseController
    {
        public AdminController(ITvvitterData data)
            : base(data)
        {
        }

        // GET: /Admin/
        public ActionResult Index()
        {
            var tweets = this.Data.Tweets.All().ToList();
            return View(tweets);
        }

        // GET: /Admin/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.Data.Tweets.All().FirstOrDefault(x => x.Id == id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                tweet.Id = Guid.NewGuid();
                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = this.Data.Tweets.All().FirstOrDefault(x => x.Id == id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /Admin/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                this.Data.Tweets.Update(tweet);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.Data.Tweets.All().FirstOrDefault(x => x.Id == id);
            
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tweet tweet = this.Data.Tweets.All().FirstOrDefault(x => x.Id == id);
            this.Data.Tweets.Delete(tweet);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.Data.Dispose();
            base.Dispose(disposing);
        }
    }
}
