using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.PrintCurrentDate
{
    class PrintCurrentDate
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(DateTime.Now.Year,
                DateTime.Now.Month, DateTime.Now.Day);

            Console.WriteLine(date.Year + "г. " + date.Month + "м. " +
                date.Day + "д. \n");

            Console.WriteLine(DateTime.Now);
        }
    }
}
