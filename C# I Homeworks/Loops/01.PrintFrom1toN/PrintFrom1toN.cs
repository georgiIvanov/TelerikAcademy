using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.PrintFrom1toN
{
    class PrintFrom1toN
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
