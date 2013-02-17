using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _09.First100FibonacciNums
{
    class First100FibonacciNums
    {
        static void Main(string[] args)
        {
            BigInteger a = 0;
            BigInteger b = 1;
            BigInteger nextNum = 0;

            Console.WriteLine(a);
            Console.WriteLine(b);

            for (int i = 0; i < 98; i++)
            {
                nextNum = a + b;
                Console.WriteLine(nextNum);
                a = b;
                b = nextNum;
            }
        }
    }
}
