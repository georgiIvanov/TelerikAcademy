using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.PrintNumber
{
    class PrintNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,15}", number);

            Console.WriteLine("{0,15:X}", number);

            Console.WriteLine("{0,15:P}", number);

            Console.WriteLine("{0,15:E}", number);


        }
    }
}
