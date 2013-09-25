using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MovieController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();

        // GET: /Movie/
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: /Movie/GetMovie/5
        public ActionResult GetMovie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", movie);
        }

        // GET: /Movie/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: /Movie/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: /Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies
                .Include("LeadMaleActor")
                .Include("LeadFemaleActor").FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", movie);
        }

        // POST: /Movie/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // 
        // Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(movie).State = EntityState.Modified;
                var foundMovie = db.Movies.Single(x => x.Id == movie.Id);
                UpdateEntityValues(movie, foundMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView("_Edit", movie);
        }

        private static void UpdateEntityValues(Movie movie, Movie foundMovie)
        {
            foundMovie.Title = movie.Title;
            foundMovie.Studio = movie.Studio;
            foundMovie.StudioAddress = movie.StudioAddress;
            foundMovie.Year = movie.Year;
            foundMovie.Director = movie.Director;
            foundMovie.LeadFemaleActor = movie.LeadFemaleActor;
            foundMovie.LeadMaleActor = movie.LeadMaleActor;
        }

        // GET: /Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", movie);
        }

        // POST: /Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
