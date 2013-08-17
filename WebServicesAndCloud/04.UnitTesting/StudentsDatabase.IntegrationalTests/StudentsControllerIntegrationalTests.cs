using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using StudentsDatabase.Repositories;
using StudentsDatabase.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Newtonsoft.Json;
using StudentsDatabase.Tests;
using System.Linq;
using System.Net;

namespace StudentsDatabase.IntegrationalTests
{
    [TestClass]
    public class StudentsControllerIntegrationalTests
    {
        [TestMethod]
        public void PostEmptyStudent()
        {
            //var school = new School().AddSchoolToDatabase(
            var mockRepository = Mock.Create<DbStudentRepository>();

            var student = new Student();

            Mock.Arrange(() => mockRepository.Add(Arg.IsAny<Student>()))
                .Throws(new DbEntityValidationException());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var responce = server.CreatePostRequest("api/students", JsonConvert.SerializeObject(student));

            Assert.AreEqual((int)responce.StatusCode, 500);


        }

        [TestMethod]
        public void PostStudentWithoutSchool()
        {
            //var school = new School().AddSchoolToDatabase(
            var mockRepository = Mock.Create<DbStudentRepository>();

            var student = new Student()
                .AddFirstName("ivan")
                .AddLastName("petkov")
                .AddAge(8)
                .AddGrade(2);
            
            Mock.Arrange(() => mockRepository.Add(Arg.IsAny<Student>()))
                .Throws(new DbEntityValidationException());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var responce = server.CreatePostRequest("api/students", JsonConvert.SerializeObject(student));

            Assert.AreEqual(responce.StatusCode, HttpStatusCode.InternalServerError);
        }

        [TestMethod]
        public void PostStudent()
        {
            //var school = new School().AddSchoolToDatabase(
            var mockRepository = Mock.Create<DbStudentRepository>();
            bool added = false;

            var student = new Student()
                .AddFirstName("ivan")
                .AddLastName("petkov")
                .AddAge(8)
                .AddGrade(2)
                .AddSchoolId(1);

            Mock.Arrange(() => mockRepository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => added = true)
                .Returns(student);

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var responce = server.CreatePostRequest("api/students", JsonConvert.SerializeObject(student));

            Assert.AreEqual(responce.StatusCode, HttpStatusCode.Created);
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetStudents()
        {
            //var school = new School().AddSchoolToDatabase(
            var mockRepository = Mock.Create<DbStudentRepository>();
            bool added = false;

            var student = new Student()
                .AddFirstName("ivan")
                .AddLastName("petkov")
                .AddAge(8)
                .AddGrade(2)
                .AddSchoolId(1);

            //IQueryable

            Mock.Arrange(() => mockRepository.All())
                .DoInstead(() => added = true)
                .Returns((new Student[] {student, student}).AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var responce = server.CreateGetRequest("api/students");
            
            Assert.AreEqual(responce.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(added);
        }

    }
}
