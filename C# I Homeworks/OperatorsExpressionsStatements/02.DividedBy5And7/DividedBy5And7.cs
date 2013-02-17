using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.DividedBy5And7
{
    class DividedBy5And7
    {
        static void Main(string[] args)
        {
            int number = new int();
            int.TryParse(Console.ReadLine(), out number);

            if (number % 5 == 0 && number % 7 == 0)
            {
                Console.WriteLine("Can be divided by 5 and 7");
            }
            else
            {
                Console.WriteLine("Can't be divided by 5 or 7");
            }


        }
    }
}
