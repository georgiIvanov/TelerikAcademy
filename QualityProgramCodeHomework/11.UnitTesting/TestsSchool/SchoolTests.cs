using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsSchool
{
    using School;
    
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CreateSchool()
        {
            School school = new School();
            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void AddStudent()
        {
            School school = new School();
            school.AddStudent("lala", 10000);
            Assert.AreEqual("lala", school.GetStudentByUID(10000).Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddBadIDStudentLow()
        {
            School school = new School();
            school.AddStudent("lala", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddBadIDStudentHigh()
        {
            School school = new School();
            school.AddStudent("lala", 100000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicatedIDStudent()
        {
            School school = new School();
            school.AddStudent("lala", 10000);
            school.AddStudent("2222", 10000);
        }

        [TestMethod]
        public void AddCourse()
        {
            School school = new School();
            school.AddCourse(new Course("lol"));
            Assert.AreEqual("lol",school.GetCourseByName("lol").CourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicatedCourse()
        {
            School school = new School();
            school.AddCourse(new Course("lol"));
            school.AddCourse(new Course("lol"));
        }

        [TestMethod]
        public void AddCourseWithStudents()
        {
            School school = new School();
            school.AddCourse("lol",  new Student("lele", 10000), new Student("male", 10001));
            Assert.AreEqual("lol", school.GetCourseByName("lol").CourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetInvalidCourseName()
        {
            School school = new School();
            school.GetCourseByName("lal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetInvalidStudentID()
        {
            School school = new School();
            school.GetStudentByUID(10000);
        }
    }
}
