using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.GreaterNum
{
    class GreaterNum
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int result = (a > b) ? a : b;
            Console.WriteLine(result);
        }
    }
}
