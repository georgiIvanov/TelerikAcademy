using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Person
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Person> peopleToTest = new List<Person>();
            peopleToTest.Add(new Person("lala", null));
            peopleToTest.Add(new Person("lala1", null));
            peopleToTest.Add(new Person("fafa", 333));
            peopleToTest.Add(new Person("fafa", null));

            Assert.AreEqual("lala age not specified", peopleToTest[0].ToString());
            Assert.AreEqual("lala1 age not specified", peopleToTest[1].ToString());
            Assert.AreEqual("fafa 333", peopleToTest[2].ToString());
            Assert.AreEqual("fafa age not specified", peopleToTest[3].ToString());
        }
    }
}
