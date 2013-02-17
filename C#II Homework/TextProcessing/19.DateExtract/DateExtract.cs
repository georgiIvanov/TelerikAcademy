using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace _19.DateExtract
{
    class DateExtract
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text with dates: ");
            string inputString = Console.ReadLine();
            MatchCollection matches = Regex.Matches(inputString, @"\b\d{2}.\d{2}.\d{4}\b");

            DateTime date;
            foreach (var match in matches)
            {
                if (DateTime.TryParseExact(match.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out date))
                {
                    Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
                }
            }


        }
    }
}
