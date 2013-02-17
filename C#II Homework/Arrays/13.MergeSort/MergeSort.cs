using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13.MergeSort
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            int[] numbers = new int[nSize];

            Console.WriteLine("Enter {0} numbers: ", nSize);
            for (int i = 0; i < nSize; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int[] tempArr = new int[numbers.Length];
            int currLen = 1, currPos = 0, left = 0, right = 0;

            while (currLen <= nSize)
            {
                for (int i = 0; i < nSize; i += currLen * 2)
                {
                    while (currPos < nSize)
                    {
                        if (left < currLen && right < currLen && i + right + currLen < nSize)
                        {
                            if (numbers[i + left] <= numbers[i + right + currLen])
                            {
                                tempArr[currPos] = numbers[i + left];
                                left++;
                            }
                            else
                            {
                                tempArr[currPos] = numbers[i + right + currLen];
                                right++;
                            }
                        }
                        else if (left < currLen)
                        {
                            tempArr[currPos] = numbers[i + left];
                            left++;
                        }
                        else if (right < currLen)
                        {
                            tempArr[currPos] = numbers[i + right + currLen];
                            right++;
                        }
                        else break;

                        currPos++;
                    }
                    left = 0;
                    right = 0;
                }
                currLen *= 2;
                currPos = 0;
                for (int i = 0; i < nSize; i++)
                {
                    numbers[i] = tempArr[i];
                }
            }

            Console.Write("Sorted: ");
            for (int i = 0; i < nSize; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
