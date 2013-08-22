using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        // GET api/students
        public HttpResponseMessage Get()
        {
            StudentModel[] students = new StudentModel[]
            {
                new StudentModel()
                {
                    FirstName = "Doncho",
                    LastName = "Minkov",
                    Marks =  new MarkModel[] {
                        new MarkModel()
                        {
                            Subject = "Math",
                            Score = 5.9
                        }, new MarkModel()
                        {
                            Subject = "BG",
                            Score = 3
                        },
                        new MarkModel()
                        {
                            Subject = "JavaScript",
                            Score = 6
                        },
                    }
                },
                new StudentModel()
                {
                    FirstName = "Svetlin",
                    LastName = "Nakov",
                    Marks =  new MarkModel[] {
                        new MarkModel()
                        {
                            Subject = "Math",
                            Score = 4.9
                        },
                        new MarkModel()
                        {
                            Subject = "JavaScript",
                            Score = 3
                        },
                    }
                },
                new StudentModel()
                {
                    FirstName = "Pesho",
                    LastName = "Ivanov",
                    Marks =  new MarkModel[] {
                        new MarkModel()
                        {
                            Subject = "BG",
                            Score = 3
                        },
                        new MarkModel()
                        {
                            Subject = "JavaScript",
                            Score = 6
                        },
                    }
                },
                new StudentModel()
                {
                    FirstName = "Marian",
                    LastName = "Marinov",
                    
                },
                 new StudentModel()
                {
                    FirstName = "Minko",
                    LastName = "Donchov",
                    Marks =  new MarkModel[] {
                        new MarkModel()
                        {
                            Subject = "Math",
                            Score = 5.9
                        }, new MarkModel()
                        {
                            Subject = "BG",
                            Score = 3
                        },
                        new MarkModel()
                        {
                            Subject = "JavaScript",
                            Score = 6
                        },
                    }
                }
            };

            var responce = Request.CreateResponse(HttpStatusCode.OK, students, "application/json");

            return responce;
        }

        // GET api/students/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/students
        public void Post([FromBody]string value)
        {
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/students/5
        public void Delete(int id)
        {
        }
    }
}
