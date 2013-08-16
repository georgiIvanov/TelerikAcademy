using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using Telerik.JustMock;
using StudentsDatabase.Repositories;
using StudentsDatabase.Models;
using StudentsDatabase.Controllers;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace StudentsDatabase.Tests.Controllers
{
    [TestClass]
    public class StudentsControllerTests
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/categories");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void PostStudent()
        {
            var repository = new FakeStudentRepository(new DbContext("JustMock sucks"));

            var student = new Student();

            var controller = new StudentsController(repository);
            SetupController(controller);

            controller.Post(student);

            Assert.IsTrue(repository.students.Count == 1);

        }

        [TestMethod]
        public void GetStudents()
        {
            var repository = new FakeStudentRepository(new DbContext("JustMock sucks"));

            for (int i = 0; i < 3; i++)
            {
                repository.students.Add(new Student().AddId(i));
            }

            var controller = new StudentsController(repository);
            SetupController(controller);

            var returned = controller.Get();

            Assert.IsTrue(returned.Count() == 3);
        }

        [TestMethod]
        public void GetStudent()
        {
            var repository = new FakeStudentRepository(new DbContext("JustMock sucks"));

            for (int i = 1; i <= 3; i++)
            {
                repository.students.Add(new Student().AddId(i));
            }

            var controller = new StudentsController(repository);
            SetupController(controller);

            var returned = controller.Get(3);

            Assert.IsTrue(returned.Id == 3);
        }

        [TestMethod]
        public void GetStudentMarks()
        {
            var repository = new FakeStudentRepository(new DbContext("JustMock sucks"));


            for (int i = 1; i <= 3; i++)
            {
                repository.students.Add(new Student()
                {
                    Marks = new HashSet<Mark>(Enumerable.Repeat<Mark>(new Mark()
                    {
                        Subject = "math",
                        Value = 5.5,
                        StudentId = i
                    }, 1))
                }.AddId(i));
            }

            repository.students.Add(new Student()
            {
                 Marks = new HashSet<Mark>(Enumerable.Repeat<Mark>(new Mark()
                    {
                        Subject = "math",
                        Value = 3,
                        StudentId = 4
                    }, 1))
            }.AddId(4));

            var controller = new StudentsController(repository);
            SetupController(controller);

            var returned = controller.Get("math", 4);

            Assert.IsTrue(returned.Count() == 3);
        }
    }
}
