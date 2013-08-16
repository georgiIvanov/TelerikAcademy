using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using StudentsDatabase.Models;
using StudentsDatabase.Repositories;
using System.Transactions;
using SchoolDatabase.DataLayer;
using System.Linq;

namespace StudentsDatabase.Tests.Controllers
{
    [TestClass]
    public class SchoolsRepositoryTest
    {
        public DbContext dbContext { get; set; }

        public IRepository<School> schoolRepository { get; set; }

        private static TransactionScope tranScope;

        public SchoolsRepositoryTest()
        {
            this.dbContext = new StudentsDatabaseContext();
            this.schoolRepository = new DbSchoolRepository(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void InsertSchool()
        {
            string schoolName = "TVU";

            var school = new School()
                .AddName(schoolName);

            var created = this.schoolRepository.Add(school);
            var found = dbContext.Set<School>().Find(created.SchoolId);

            Assert.IsTrue(found.SchoolId > 0);
            Assert.AreEqual(schoolName, found.Name);
        }

        [TestMethod]
        public void InsertSchoolWithLocation()
        {
            string schoolName = "luuudnica";
            string location = "4ti kilometar";

            var school = new School()
                .AddName(schoolName)
                .AddLocation(location);

            var created = this.schoolRepository.Add(school);
            var found = dbContext.Set<School>().Find(created.SchoolId);

            Assert.AreEqual(schoolName, found.Name);
            Assert.AreEqual(location, found.Location);
            Assert.IsTrue(found.SchoolId > 0);

        }

        [TestMethod]
        public void InsertSchoolWithStudent()
        {
            string schoolName = "TVU";
            string studentFirstName = "Ivan4o";
            string studentLastName = "Kalpazan4o";

            var student = new Student()
                .AddFirstName(studentFirstName)
                .AddLastName(studentLastName);

            var school = new School()
                .AddName(schoolName)
                .AddStudent(student);

            var created = this.schoolRepository.Add(school);
            var found = dbContext.Set<School>().Find(created.SchoolId);
            var studentInSchool = found.Students.First();

            Assert.AreEqual(schoolName, found.Name);
            Assert.AreEqual(student.FirstName, studentInSchool.FirstName);
            Assert.AreEqual(student.LastName, studentInSchool.LastName);
            Assert.AreEqual(student.Id, studentInSchool.Id);
            Assert.AreEqual(school.SchoolId, studentInSchool.SchoolId);
        }
    }

    
}
