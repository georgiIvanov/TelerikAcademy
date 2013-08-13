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
    public class SchoolsController : ApiController
    {
        DbSchoolRepository schoolRepository;

        public SchoolsController(IRepository<School> schoolRepository)
        {
            this.schoolRepository = (DbSchoolRepository)schoolRepository;
        }

        // GET api/schools
        public IEnumerable<School> Get()
        {
            var schools = this.schoolRepository.All().ToList();

            foreach (var sc in schools)
            {
                sc.Students = this.schoolRepository.GetStudentsInSchool(sc);
            }

            return schools;

        }

        // GET api/schools/5
        public School Get(int id)
        {
            return this.schoolRepository.Get(id);
        }

        // POST api/schools
        public HttpResponseMessage Post(School value)
        {
            var created = this.schoolRepository.Add(value);

            var responce = Request.CreateResponse<School>(HttpStatusCode.Created, created);
            var resourceLink = Url.Link("DefaultApi", new { id = created.SchoolId });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }

        // PUT api/schools/5
        public HttpResponseMessage Put(int id, School value)
        {
            if (id != value.SchoolId || value == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var updated = this.schoolRepository.Update(id, value);

            var responce = Request.CreateResponse<School>(HttpStatusCode.Created, updated);
            var resourceLink = Url.Link("DefaultApi", new { id = updated.SchoolId });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }

        // DELETE api/schools/5
        public HttpResponseMessage Delete(int id)
        {
            var found = this.schoolRepository.Get(id);
            if (found != null)
            {
                var responce = Request.CreateResponse<School>(HttpStatusCode.OK, found);
                var resourceLink = Url.Link("DefaultApi", new { id = found.SchoolId });

                responce.Headers.Location = new Uri(resourceLink);
                this.schoolRepository.Delete(id);

                return responce;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
