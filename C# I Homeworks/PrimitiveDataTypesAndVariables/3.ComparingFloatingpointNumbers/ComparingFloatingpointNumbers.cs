using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.ComparingFloatingpointNumbers
{
    class ComparingFloatingpointNumbers
    {
        static void Main(string[] args)
        {
            decimal num1 = 5.600002m,
                num2 = 5.000001m;
            if (Math.Abs(num1 - num2) <= 0.000001m)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }


        }
    }
}
