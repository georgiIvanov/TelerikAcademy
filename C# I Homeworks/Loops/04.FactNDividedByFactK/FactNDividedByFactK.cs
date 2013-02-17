using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.FactNDividedByFactK
{
    class FactNDividedByFactK
    {
        static void Main(string[] args)
        {
            int n = 0;
            int k = 0;
            do
            {
                n = int.Parse(Console.ReadLine());
                k = int.Parse(Console.ReadLine());
            } while (1 > n || k < n);



            int result = 1;
            for (int i = n + 1; i <= k; i++)
            {
                result *= i;
            }

            Console.WriteLine(1d/result);


        }
    }
}
