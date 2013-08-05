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
using System.Threading;
using System.Globalization;

namespace _01.MusicStore.Controllers
{
    public class ArtistController : ApiController
    {
        /// <summary>
        /// 
        /// use fiddler requests in the comments below to check the services
        /// 
        /// </summary>

        private MusicStoreContext db = new MusicStoreContext();

        // GET api/Artist
        public IEnumerable<Artist> GetArtists()
        {

            //Host: localhost:11302
            //Accept: application/json
            //User-Agent: Fiddler


            return db.Artists.AsEnumerable();
        }

        // GET api/Artist/5
        public Artist GetArtist(int id)
        {

            //Host: localhost:11302
            //Accept: application/json
            //User-Agent: Fiddler


            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artist;
        }

        // PUT api/Artist/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            // header
            //User-Agent: Fiddler
            //Host: localhost:11302
            //Content-type: application/json
            //Content-Length: 91

            // request body
            //    {
            //"ArtistId":"1",
            //"Name": "Pesho",
            //"Country": "Somalia",
            //"DateOfBirth": "1942.01.01"
            //}

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != artist.ArtistId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(artist).State = EntityState.Modified;

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

        // POST api/Artist
        public HttpResponseMessage PostArtist(Artist artist)
        {

            ////header
            //User-Agent: Fiddler
            //Host: localhost: *****
            //Content-type: application/json
            //Content-Length: 77

            ////request body
            //{
            //"Name": "Pesho",
            //"Country": "Bulgaria",
            //"DateOfBirth": "1942.01.01"
            //}


            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artist/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}