using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CheckForLeapYear
{
    class CheckForLeapYear
    {
        static void Main(string[] args)
        {
            DateTime year = new DateTime(1,1,1);
            Console.WriteLine("Enter year: ");
            year = year.AddYears(int.Parse(Console.ReadLine()) - 1);
            if (year.Year % 4 == 0)
            {
                Console.WriteLine("Year is leap");
            }
            else
            {
                Console.WriteLine("Year is not leap");
            }

            Console.WriteLine(year);

        }
    }
}
