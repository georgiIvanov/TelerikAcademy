using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ArrayComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] first = new int[3];

            Console.WriteLine("Enter 3 numbers, each on new line");

            for (int i = 0; i < 3; i++)
            {
                first[i] = int.Parse(Console.ReadLine());
            }

            int[] second = new int[3];

            Console.WriteLine("Enter 3 numbers, each on new line");

            for (int i = 0; i < 3; i++)
            {
                second[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                if (first[i] > second[i])
                {
                    Console.WriteLine("Number from first array is bigger");
                }
                else if (first[i] < second[i])
                {
                    Console.WriteLine("Number from second array is bigger");
                }
                else
                {
                    Console.WriteLine("Numbers are equal");
                }
            }


        }
    }
}
