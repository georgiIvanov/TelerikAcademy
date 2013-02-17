using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.NumberInArray
{
    class NumberInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number for search: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            Console.WriteLine("Enter {0} numbers: ", n);
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("Frequency of {0} is {1}", number, FindNumberFrequency(numbers, number));
        }

        static int FindNumberFrequency(int[] array, int number)
        {
            int freq = 0;
            foreach (var item in array)
            {
                if (item == number)
                {
                    freq++;
                }
            }

            return freq;
        }
    }
}
