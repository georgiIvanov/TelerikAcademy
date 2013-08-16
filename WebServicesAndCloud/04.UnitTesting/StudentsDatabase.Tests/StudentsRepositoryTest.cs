using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using StudentsDatabase.Repositories;
using System.Transactions;
using SchoolDatabase.DataLayer;
using StudentsDatabase.Models;

namespace StudentsDatabase.Tests.Controllers
{
    [TestClass]
    public class StudentsRepositoryTest
    {
        DbContext dbContext;

        IRepository<Student> studentsRepository;

        static TransactionScope transactionScope;

        public StudentsRepositoryTest()
        {
            this.dbContext = new StudentsDatabaseContext();
            this.studentsRepository = new DbStudentRepository(this.dbContext);
            
        }

        public School AddSchool(string name = "TVU", string location = "gorata")
        {
            var school = this.dbContext.Set<School>().Add(
                new School()
                .AddName(name)
                .AddLocation(location));

            return school;
        }

        [TestInitialize]
        public void TestInit()
        {
            transactionScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void InsertBasicStudent()
        {
            var school = AddSchool();

            var student = new Student()
                .AddFirstName("Pesho")
                .AddLastName("Ivanov")
                .AddSchoolId(school.SchoolId);

            var created = this.studentsRepository.Add(student);
            var found = this.dbContext.Set<Student>().Find(created.Id);

            Assert.AreEqual(student.FirstName, found.FirstName);
            Assert.AreEqual(student.LastName, found.LastName);
            Assert.AreEqual(student.SchoolId, school.SchoolId);
            Assert.IsTrue(student.Id > 0);
            Assert.IsTrue(student.SchoolId > 0);
        }

        [TestMethod]
        public void InsertStudentAge()
        {
            var school = AddSchool();

            var student = new Student()
                .AddFirstName("Pesho")
                .AddAge(20)
                .AddSchoolId(school.SchoolId);

            var created = this.studentsRepository.Add(student);
            var found = this.dbContext.Set<Student>().Find(created.Id);

            Assert.AreEqual(student.FirstName, found.FirstName);
            Assert.AreEqual(student.Age, found.Age);
        }

        [TestMethod]
        public void InsertStudentGrade()
        {
            var school = AddSchool();

            var student = new Student()
                .AddFirstName("Pesho")
                .AddGrade(5)
                .AddSchoolId(school.SchoolId);

            var created = this.studentsRepository.Add(student);
            var found = this.dbContext.Set<Student>().Find(created.Id);

            Assert.AreEqual(student.FirstName, found.FirstName);
            Assert.AreEqual(student.Grade, found.Grade);
        }

        [TestMethod]
        public void InsertStudentSchoolCheck()
        {
            var school = AddSchool("Mrete", "mladost");

            var student = new Student()
                .AddFirstName("Pesho")
                .AddSchoolId(school.SchoolId);

            var created = this.studentsRepository.Add(student);
            var found = this.dbContext.Set<Student>().Find(created.Id);

            Assert.AreEqual(student.SchoolId, school.SchoolId);
            Assert.IsTrue(student.Id > 0);
            Assert.IsTrue(student.SchoolId > 0);
            Assert.AreEqual(student.School.Name, school.Name);
            Assert.AreEqual(student.School.Location, school.Location);
        }

        
    }
}
