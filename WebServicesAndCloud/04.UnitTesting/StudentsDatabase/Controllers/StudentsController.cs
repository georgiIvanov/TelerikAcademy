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
            var studentEntities =  this.studentsRepository.All().ToList();
            var students =
                                from stud in studentEntities
                                select new Student()
                                {
                                    Id = stud.Id,
                                    FirstName = stud.FirstName,
                                    LastName = stud.LastName,
                                    Age = stud.Age,
                                    Grade = stud.Grade,
                                    Marks = stud.Marks
                                };

            return students;
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
        public HttpResponseMessage Put(int id, Student value)
        {
            if (id != value.Id || value == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            var updated = this.studentsRepository.Update(id, value);

            var responce = Request.CreateResponse<Student>(HttpStatusCode.Created, updated);
            var resourceLink = Url.Link("DefaultApi", new { id = updated.Id });

            responce.Headers.Location = new Uri(resourceLink);

            return responce;

        }

        // DELETE api/student/5
        public HttpResponseMessage Delete(int id)
        {
            var found = this.studentsRepository.Get(id);
            if (found != null)
            {
                var responce = Request.CreateResponse<Student>(HttpStatusCode.OK, found);
                var resourceLink = Url.Link("DefaultApi", new { id = found.Id });

                responce.Headers.Location = new Uri(resourceLink);
                this.studentsRepository.Delete(id);

                return responce;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
