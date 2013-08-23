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
        Student[] students;

        public StudentsController()
        {
            this.students = new Student[]{
                new Student(){
                    Id = 1,
                    Name = "Ivan",
                    Grade = 3,
                    Marks = new MarkModel[]{
                        new MarkModel(){
                            Value = 5,
                            Subject = "C#"
                        },
                        new MarkModel(){
                            Value = 2,
                            Subject = "JavaScript"
                        },
                        new MarkModel(){
                            Value = 6,
                            Subject = "HTML Basics"
                        },
                    }
                },
                new Student(){
                    Id = 2,
                    Name = "Doncho Minkov",
                    Grade = 6,
                    Marks = new MarkModel[]{

                        new MarkModel(){
                            Value = 3,
                            Subject = "JavaScript"
                        }
                    }
                },
                new Student(){
                    Id = 3,
                    Name = "Giorgy",
                    Grade = 8,
                    Marks = new MarkModel[]{
                        new MarkModel(){
                            Value = 3,
                            Subject = "C#"
                        },
                        new MarkModel(){
                            Value = 3,
                            Subject = "JavaScript"
                        },
                        new MarkModel(){
                            Value = 3,
                            Subject = "HTML Basics"
                        },
                    }
                },
            };
        }
        // GET api/students
        public IEnumerable<StudentModel> Get()
        {
            var sent = new StudentModel[]{
                new StudentModel(){
                    Id = students[0].Id,
                    Name = students[0].Name,
                    Grade = students[0].Grade
                },
                new StudentModel(){
                    Id = students[1].Id,
                    Name = students[1].Name,
                    Grade = students[1].Grade
                },
                new StudentModel(){
                    Id = students[2].Id,
                    Name = students[2].Name,
                    Grade = students[2].Grade
                },
            };

            return sent;
        }

        [ActionName("getmarks")]
        public IEnumerable<MarkModel> Get(int studentId)
        {
            var found = (from s in students
                         where s.Id == studentId
                         select s).FirstOrDefault();

            return found.Marks;
        }

        
    }
}
