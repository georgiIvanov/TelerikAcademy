using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.BinSearch
{
    class BinSearch
    {
        static void Main(string[] args)
        {
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            Console.WriteLine("Enter {0} numbers, each on new line: ", n);
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);

            Console.Write("\nNumber <= K: ");
            Console.WriteLine(Array.BinarySearch(numbers, k+1));
            


        }
    }
}
