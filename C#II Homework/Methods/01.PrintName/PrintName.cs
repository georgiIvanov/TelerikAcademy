using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.PrintName
{
    class PrintName
    {
        static void Main(string[] args)
        {
            GetAndPrintName();
        }

        static void GetAndPrintName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("Hello, {0}", name);
        }
    }
}
