using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16.DaysBetweenDates
{
    class DaysBetweenDates
    {
        static void Main(string[] args)
        {
            string[] dateParts = new string[3];
            Console.Write("Enter first date: ");
            string inputString = Console.ReadLine();

            dateParts = inputString.Split('.');
            DateTime firstDate = new DateTime();
            firstDate = firstDate.AddDays(double.Parse(dateParts[0]) - 1);
            firstDate = firstDate.AddMonths(int.Parse(dateParts[1]) - 1);
            firstDate = firstDate.AddYears(int.Parse(dateParts[2]) - 1);

            Console.Write("Enter second date: ");
            inputString = Console.ReadLine();

            dateParts = inputString.Split('.');
            DateTime secondDate = new DateTime();
            secondDate = secondDate.AddDays(double.Parse(dateParts[0]) - 1);
            secondDate = secondDate.AddMonths(int.Parse(dateParts[1]) - 1);
            secondDate = secondDate.AddYears(int.Parse(dateParts[2]) - 1);

            TimeSpan distance = new TimeSpan();
            distance = secondDate - firstDate;
            Console.WriteLine(Math.Abs(distance.Days));
        }
    }
}
