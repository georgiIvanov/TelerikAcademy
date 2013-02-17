using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.NumNotDivisibleBy3And7
{
    class NumNotDivisibleBy3And7
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                if (i % 3 == 0 && i % 7 == 0)
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();


        }
    }
}
