using StudentsDatabase.Models;
using StudentsDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsDatabase.Controllers
{
    public class MarksController : ApiController
    {
        IRepository<Mark> markRepository;

        public MarksController(IRepository<Mark> markRepository)
        {
            this.markRepository = markRepository;
        }

        // GET api/marks
        public IEnumerable<Mark> Get()
        {
            return this.markRepository.All();
        }

        // GET api/marks/5
        public Mark Get(int id)
        {
            return this.markRepository.Get(id);
        }

        // POST api/marks
        public HttpResponseMessage Post(Mark value)
        {
            var created = this.markRepository.Add(value);

            var responce = Request.CreateResponse<Mark>(HttpStatusCode.Created, created);
            var resourceLink = Url.Link("DefaultApi", new { id = created.Id });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }

        // PUT api/marks/5
        public HttpResponseMessage Put(int id, Mark value)
        {
            if (id != value.Id || value == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var updated = this.markRepository.Update(id, value);

            var responce = Request.CreateResponse<Mark>(HttpStatusCode.Created, updated);
            var resourceLink = Url.Link("DefaultApi", new { id = updated.Id });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }

        // DELETE api/marks/5
        public HttpResponseMessage Delete(int id)
        {
            var found = this.markRepository.Get(id);
            if (found != null)
            {
                var responce = Request.CreateResponse<Mark>(HttpStatusCode.OK, found);
                var resourceLink = Url.Link("DefaultApi", new { id = found.Id });

                responce.Headers.Location = new Uri(resourceLink);
                this.markRepository.Delete(id);

                return responce;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
