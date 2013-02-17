using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _13.TrailingZerosOfN
{
    class TrailingZerosOfN
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger number = 1;

            for (int i = 1; i <= n; i++)
            {
                number *= i;
            }
            Console.WriteLine(number);
            int zeros = 0;
            while (number % 5 == 0)
            {
                zeros++;
                number /= 5;
            }


            Console.WriteLine(zeros);

        }
    }
}

//for 50000!
//12499 trailing zeros