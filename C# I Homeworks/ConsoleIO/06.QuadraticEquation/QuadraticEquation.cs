using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double D = b * b - 4 * a * c;

            if (D > 0)
            {
                double SqrtD = Math.Sqrt(D);
                double x1 = (-b - SqrtD) / (2 * a);
                double x2 = (-b + SqrtD) / (2 * a);
                Console.WriteLine("x1: {0}", x1);
                Console.WriteLine("x2: {0}", x2);
            }
            else if (D == 0)
            {
                double x12 = -b / 2 * a;
                Console.WriteLine("Double root, x1/2: {0}", x12);
            }
            else if (D < 0)
            {
                Console.WriteLine("There are no real roots");
            }

        }
    }
}
