using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.MinMaxNumber
{
    class MinMaxNumber
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int min = int.MaxValue, max = int.MinValue, number = 0;

            for (int i = 1; i <= N; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number < min)
                {
                    min = number;
                }
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine();

        }
    }
}
