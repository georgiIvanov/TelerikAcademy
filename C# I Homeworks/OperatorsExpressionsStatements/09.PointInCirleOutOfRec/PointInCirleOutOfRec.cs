using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _09.PointInCirleOutOfRec
{
    class PointInCirleOutOfRec
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            double y = double.Parse(Console.ReadLine());
          
            if (((x - 1) * (x - 1) + (y - 1) * (y - 1)) < 9)
            {
                if(y > 1)
                {
                    Console.WriteLine("Point is in circle, outside rec");
                }
                else if ((y < 1 || y > -1) && x < -1)
                {
                    Console.WriteLine("Point is in circle, outside rec");
                }
                else if (y < -1)
                {
                    Console.WriteLine("Point is in circle, outside rec");
                }
                else
                {
                    Console.WriteLine("Point doesn't meet conditions");
                }
            }
            

        }
    }
}
