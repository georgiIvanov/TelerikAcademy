using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._1toNSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0} ", i);
            }

            Console.WriteLine();
        }
    }
}
