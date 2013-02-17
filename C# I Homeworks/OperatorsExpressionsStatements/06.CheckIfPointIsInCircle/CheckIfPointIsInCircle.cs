using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.CheckIfPointIsInCircle
{
    class CheckIfPointIsInCircle
    {
        static void Main(string[] args)
        {
            Console.Write("Enter x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            int y = int.Parse(Console.ReadLine());

            if( ((x - 0)*(x - 0) + (y - 0)*(y - 0)) < 25 )
            {
                Console.WriteLine("Point is in circle");
            }


        }
    }
}
