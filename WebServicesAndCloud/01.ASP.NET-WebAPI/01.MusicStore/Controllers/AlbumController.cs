using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using _01.MusicStoreModels;
using _01.MusicStoreDAL;

namespace _01.MusicStore.Controllers
{
    public class AlbumController : ApiController
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET api/Album
        public IEnumerable<Album> GetAlbums()
        {
            return db.Albums.Include("Artists").Include("Songs").AsEnumerable();
        }

        // GET api/Album/5
        public Album GetAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return album;
        }

        // PUT api/Album/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {

            // header
            //User-Agent: Fiddler
            //Host: localhost:11302
            //Content-type: application/json
            //Content-Length: 177


            // req body
            //{
            //"AlbumId": "1",
            //"Title": "I Love WebServicessss",
            //"ReleaseDate": "2002.11.03",
            //"Producer": "The Big Chicken"
            //}

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != album.AlbumId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(album).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Album
        public HttpResponseMessage PostAlbum(Album album)
        {

            // header
            //User-Agent: Fiddler
            //Host: localhost:11302
            //Content-type: application/json
            //Content-Length: 97

            // req body
            //{
            //"Title": "I Love WebServices",
            //"ReleaseDate": "2002.11.03",
            //"Producer": "The Big Chicken"
            //}

            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.AlbumId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Album/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}