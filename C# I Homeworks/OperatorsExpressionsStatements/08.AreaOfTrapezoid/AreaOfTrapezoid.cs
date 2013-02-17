using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.AreaOfTrapezoid
{
    class AreaOfTrapezoid
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int area = ((a + b) / 2) * h;
            Console.WriteLine(area);



        }
    }
}
