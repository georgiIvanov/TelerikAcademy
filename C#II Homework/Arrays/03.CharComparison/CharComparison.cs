using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.CharComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] first = new char[3];

            Console.WriteLine("Enter 3 chars, each on new line: ");

            for (int i = 0; i < 3; i++)
            {
                first[i] = Console.ReadLine()[0];
            }

            char[] second = new char[3];

            Console.WriteLine("Enter 3 chars, each on new line: ");

            for (int i = 0; i < 3; i++)
            {
                second[i] = Console.ReadLine()[0];
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                if (first[i] > second[i])
                {
                    Console.WriteLine("Char in first array is bigger");
                }
                else if (first[i] < second[i])
                {
                    Console.WriteLine("Char in second array is bigger");
                }
                else
                {
                    Console.WriteLine("Chars are equal");
                }
            }





        }
    }
}
