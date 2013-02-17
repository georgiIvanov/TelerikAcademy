using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.TriangleSurface
{
    class TriangleSurface
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter side: ");
            double side = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter altitude to the side: ");
            double altitude = double.Parse(Console.ReadLine());

            Console.WriteLine("Surface is: {0}", side*altitude/2);

            double semiPer, surface = 0;
            double[] sides = new double[3];
            double[] multiplier = new double[3];

            Console.WriteLine("Enter 3 sides: ");
            for (int i = 0; i < 3; i++)
			{
                sides[i] = double.Parse(Console.ReadLine());
			}

            semiPer = (sides[0] + sides[1] + sides[2]) / 2;

            multiplier[0] = semiPer - sides[0];
            multiplier[1] = semiPer - sides[1];
            multiplier[2] = semiPer - sides[2];

            semiPer *= multiplier[0] * multiplier[1] * multiplier[2];
            surface = Math.Sqrt(semiPer);

            Console.WriteLine("Surface is: {0}", surface);


            Console.WriteLine("Enter two sides, each on new line: ");
            sides[0] = double.Parse(Console.ReadLine());
            sides[1] = double.Parse(Console.ReadLine());
            Console.Write("Enter the angle between them: ");
            double angle = double.Parse(Console.ReadLine());
            surface = sides[0] * sides[1] * Math.Sin(angle) / 2;
            Console.WriteLine("Surface is: {0}", surface);

        }
    }
}
