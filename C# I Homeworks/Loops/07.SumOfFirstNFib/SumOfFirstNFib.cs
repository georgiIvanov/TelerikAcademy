using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.SumOfFirstNFib
{
    class SumOfFirstNFib
    {
        static void Main(string[] args)
        {
            int a = 0, b = 1, next = 0, sum = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i < n; i++)
            {
                sum += a + b;
                next = a + b;
                a = b;
                b = next;
            }

            Console.WriteLine(sum);



        }
    }
}
