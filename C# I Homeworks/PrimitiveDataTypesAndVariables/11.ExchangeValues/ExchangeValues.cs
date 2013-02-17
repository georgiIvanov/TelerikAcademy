using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.ExchangeValues
{
    class ExchangeValues
    {
        static void Main(string[] args)
        {
            int a = 5, b = 10;
            b = b - a;
            a = a + b;
            Console.WriteLine("a:{0}   b:{1}", a, b);
        }
    }
}
