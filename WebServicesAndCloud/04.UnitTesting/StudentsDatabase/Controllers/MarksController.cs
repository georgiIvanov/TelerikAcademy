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
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/marks/5
        public void Delete(int id)
        {
        }
    }
}
