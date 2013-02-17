using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConditionalStatements
{
    class NumberExchanger
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                int temp = a;
                a = b;
                b = temp;
                Console.WriteLine("Numbers are exchanged");
            }
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
