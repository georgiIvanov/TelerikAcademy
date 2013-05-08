using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsSchool
{
    using School;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CreateCourse()
        {
            Course course = new Course("lolerskates");
            Assert.AreEqual("lolerskates", course.CourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectCourseName()
        {
            Course course = new Course("");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MoreThan30Students()
        {
            Course course = new Course("lala");
            for (int i = 0; i < 35; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + i));
            }
        }

        [TestMethod]
        public void RemoveStudentInCourse()
        {
            Course course = new Course("lala");
            course.AddStudent(new Student("lol", 10000));
            course.RemoveStudentByUID(10000);
            course.AddStudent(new Student("lol", 10000));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddRepeatingStudentInCourse()
        {
            Course course = new Course("lala");
            course.AddStudent(new Student("lol", 10000));
            course.AddStudent(new Student("lol", 10000));
        }
    }
}
