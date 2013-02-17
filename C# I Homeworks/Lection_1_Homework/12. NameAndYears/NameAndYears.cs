using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.NameAndYears
{
    class NameAndYears
    {
        static void Main(string[] args)
        {
            int yourAge;
            int.TryParse(Console.ReadLine(), out yourAge);
            Console.WriteLine(yourAge+10);
        }
    }
}
