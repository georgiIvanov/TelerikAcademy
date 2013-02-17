using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18.RemoveSort
{
    class RemoveSort
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int nSize = int.Parse(Console.ReadLine());
            int[] numbers = new int[nSize];

            Console.WriteLine("Enter {0} numbers, each on new line: ", nSize);
            for (int i = 0; i < nSize; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int[] orderedArray = new int[nSize];
            for (int i = nSize - 1; i >= 0; i--)
            {
                if (FindVariations(numbers, orderedArray, i, 0, 0))
                {
                    break;
                }
            }
        }

        static bool FindVariations(int[] numbers, int[] orderedArray, int currentNum, int i, int next)
        {
            if (i > currentNum) return false;

            for (int j = next; j < numbers.Length; j++)
            {
                orderedArray[i] = j;

                if (i == currentNum)
                {
                    if (CheckIfSorted(numbers, orderedArray, i))
                    {
                        return true;
                    }
                }

                if (FindVariations(numbers, orderedArray, currentNum, i + 1, j + 1))
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckIfSorted(int[] numbers, int[] orderedArray, int currentNum)
        {
            for (int i = 0; i < currentNum; i++)
            {
                if (numbers[orderedArray[i]] > numbers[orderedArray[i + 1]]) return false;
            }

            for (int i = 0; i <= currentNum; i++)
            {
                Console.Write("{0} ", numbers[orderedArray[i]]);
            }
            Console.WriteLine();

            return true;
        }
    }
}
