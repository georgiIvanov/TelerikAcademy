using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.CheckElementInArray
{
    class CheckElementInArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            Console.WriteLine("Enter {0} numbers: ", n);
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int num = -1;
            while (num < 0 || num > n)
            {
                Console.WriteLine("Enter index for search: ");
                num = int.Parse(Console.ReadLine());
            }

            if (CheckIfBiggerThanNeighbours(numbers, num))
            {
                Console.WriteLine("Number at index {0} is bigger than neighbours", num);
            }
            else
            {
                Console.WriteLine("Number at index {0} is not bigger than both neighbours", num);
            }

        }

        static bool CheckIfBiggerThanNeighbours(int[] arr, int index)
        {
            bool isBigger = true;
            if (index - 1 >= 0)
            {
                if (arr[index - 1] > arr[index])
                {
                    isBigger = false;
                }
            }

            if (index + 1 < arr.Length)
            {
                if (arr[index + 1] > arr[index])
                {
                    isBigger = false;
                }
            }
            return isBigger;
        }
    }
}
