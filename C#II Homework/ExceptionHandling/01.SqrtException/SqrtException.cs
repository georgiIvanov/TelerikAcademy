using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SqrtException
{
    class SqrtException
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            double num = -1;
            try
            {
                num = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
                Environment.Exit(1);
            }

            try
            {
                CalcAndPrintSqrt(num);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CalcAndPrintSqrt(double a)
        {
            if (a < 0)
            {
                throw new FormatException("Negative number");
            }
            else
            {
                a = Math.Sqrt(a);
                Console.WriteLine(a);
            }
        }
    }
}
