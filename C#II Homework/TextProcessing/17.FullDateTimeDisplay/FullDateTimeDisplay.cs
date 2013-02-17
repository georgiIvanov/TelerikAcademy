using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _17.FullDateTimeDisplay
{
    class FullDateTimeDisplay
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
            firstDate = firstDate.AddYears(int.Parse(dateParts[2].Split()[0]) - 1);
            dateParts = dateParts[2].Split(':');
            firstDate = firstDate.AddHours(double.Parse(dateParts[0].Split()[1]) + 6);
            firstDate = firstDate.AddMinutes(double.Parse(dateParts[1]) + 30);
            firstDate = firstDate.AddSeconds(double.Parse(dateParts[2]));

            Console.WriteLine("{0} {1}", firstDate, firstDate.ToString("dddd", new CultureInfo("bg-BG")));
        }
    }
}
