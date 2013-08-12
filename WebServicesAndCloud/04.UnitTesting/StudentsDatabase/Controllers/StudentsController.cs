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
    public class StudentsController : ApiController
    {
        IRepository<Student> studentsRepository;

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        // GET api/student
        public IEnumerable<Student> Get()
        {
            return this.studentsRepository.All();
        }

        // GET api/student/5
        public Student Get(int id)
        {
            return this.studentsRepository.Get(id);
        }

        // POST api/student
        public HttpResponseMessage Post(Student value)
        {
            var created = this.studentsRepository.Add(value);

            var responce = Request.CreateResponse<Student>(HttpStatusCode.Created, created);
            var resourceLink = Url.Link("DefaultApi", new { id = created.Id });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;
        }

        // PUT api/student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
        }
    }
}
