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

            //int num = -1;
            //while (num < 0 || num > n)
            //{
            //    Console.WriteLine("Enter index for search: ");
            //    num = int.Parse(Console.ReadLine());
            //}

            //if (CheckIfBiggerThanNeighbours(numbers, num))
            //{
            //    Console.WriteLine("Number at index {0} is bigger than neighbours", num);
            //}
            //else
            //{
            //    Console.WriteLine("Number at index {0} is not bigger than both neighbours", num);
            //}
            Console.WriteLine("Index of first big number {0}", CheckIfBiggerThanNeighbours(numbers));

        }

        static int CheckIfBiggerThanNeighbours(int[] arr)
        {
            bool bigFromRight = false;
            bool bigFromLeft = false;
            int indexOfBigNum = -1;
            for(int i = 1; i < arr.Length - 1; i++)
            {
                bigFromRight = false;
                bigFromLeft = false;
                if (i - 1 >= 0)
                {
                    if (arr[i - 1] < arr[i])
                    {
                        bigFromLeft = true;
                    }
                }

                if (i + 1 < arr.Length)
                {
                    if (arr[i + 1] < arr[i])
                    {
                        bigFromRight = true;
                    }
                }
                if (bigFromLeft && bigFromRight)
                {
                    indexOfBigNum = i;
                    break;
                }
            }
            return indexOfBigNum;
        }
    }
}
