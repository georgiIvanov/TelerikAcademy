using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsSchool
{
    using School;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void CreateStudent()
        {
            Student student = new Student("lol", 10000);
            Assert.IsNotNull(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IncorrectStudentID()
        {
            Student student = new Student("lol", 1);
            Assert.IsNotNull(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectStudentName()
        {
            Student student = new Student("", 10000);
        }

        [TestMethod]
        public void CorrectStudentName()
        {
            Student student = new Student("lol", 10000);
            Assert.AreEqual("lol", student.Name);
        }

        [TestMethod]
        public void CorrectStudentID()
        {
            Student student = new Student("lol", 15000);
            Assert.AreEqual(15000, student.GetUID);
        }
    }
}
