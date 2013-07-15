using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _02.CreateDAO;

namespace DOATests
{
    [TestClass]
    public class DOATests
    {
        [TestMethod]
        public void CreateEntry()
        {
            bool result = false;
            if (NorthwindDOA.InsertCustomer(69, "Selo Ltd", "This is deleted", "BG", "525"))
            {
                result = true;
            }

            NorthwindDOA.DeleteCustomer(69);

            Assert.AreEqual(true, result);

            
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            string expectedName = "updatedName";
            NorthwindDOA.InsertCustomer(0, "Selo Ltd", "This is deleted", "BG", "525");

            NorthwindDOA.UpdateCustomerName(0, expectedName);

            var firstEntry = NorthwindDOA.PrintFirstNCustomers(1).Substring(0, expectedName.Length);

            NorthwindDOA.DeleteCustomer(0);

            Assert.AreEqual(expectedName, firstEntry);
        }

        [TestMethod]
        public void InvalidCustomer()
        {
            bool result = false;
            NorthwindDOA.InsertCustomer(1, "Selo Ltd", "This is deleted", "BG", "525");

            if (NorthwindDOA.DeleteCustomer(999999))
            {
                result = true;
            }

            NorthwindDOA.DeleteCustomer(1);

            Assert.AreEqual(false, result);
        }
    }
}
