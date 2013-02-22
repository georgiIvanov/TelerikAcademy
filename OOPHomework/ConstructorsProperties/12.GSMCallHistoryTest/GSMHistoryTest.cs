using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSMTask11;
using System.Text;

namespace _12.GSMCallHistoryTest
{
    [TestClass]
    public class GSMHistoryTest
    {
        [TestMethod]
        public void TestHistoryDisplay()
        {
            GSM phone = new GSM("lala", "sumsAng", "batman", 10000.99);
            DateTime date = new DateTime();

            DateTime.TryParse("2.2.2013 14:34", out date);
            phone.MakeCall(date, "0899999999", 3.44);

            DateTime.TryParse("6.2.2013 19:34:11", out date);
            phone.MakeCall(date, "0899999999", 3.44);

            DateTime.TryParse("11.2.2013 12:32:59", out date);
            phone.MakeCall(date, "0889666999", 9.44);

            DateTime.TryParse("12.2.2013 15:30:00", out date);
            phone.MakeCall(date, "0009666999", 9.44);

            string expected = @"12-Feb-13 15:30:00
11-Feb-13 12:32:59
06-Feb-13 19:34:11
02-Feb-13 14:34:00
";

            StringBuilder sb = new StringBuilder();
            foreach (var item in phone.GetCallsByDate())
            {
                sb.AppendLine(item.ToString());
            }

            Assert.AreEqual(expected, sb.ToString());
        }

        [TestMethod]
        public void TestCallRate()
        {
            GSM phone = new GSM("lala", "sumsAng", "batman", 10000.99);

            phone.MakeCall(DateTime.Now, "0899999999", 3.44);
            phone.MakeCall(DateTime.Now, "0899999999", 3.44);
            phone.MakeCall(DateTime.Now, "0889666999", 9.44);
            phone.MakeCall(DateTime.Now, "0009666999", 9.44);

            phone.setCallRate = 0.37;

            Assert.AreEqual("9.5312", Convert.ToString(phone.CalculateTotalPriceOfCalls()));

            phone.DeleteCall(3);
            Assert.AreEqual("6.0384", Convert.ToString(phone.CalculateTotalPriceOfCalls()));

            phone.ClearCallHistory();
            Assert.AreEqual("0", Convert.ToString(phone.CalculateTotalPriceOfCalls()));
        }
    }
}
