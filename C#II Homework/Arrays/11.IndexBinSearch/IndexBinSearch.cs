using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.IndexBinSearch
{
    class IndexBinSearch
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            int searchedIndex = int.MinValue;

            while (searchedIndex >= nSize || searchedIndex < 0)
            {
                Console.Write("Enter index for search: ");
                searchedIndex = int.Parse(Console.ReadLine());
            }
            
            int[] numbers = new int[nSize];

            Console.WriteLine("Enter {0} numbers: ", nSize);
            for (int i = 0; i < nSize; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int left = 0, right = nSize, index;

            while (true)
            {
                index = MidPoint(left, right);
                if (index < searchedIndex)
                {
                    left = index;
                }
                else if (index > searchedIndex)
                {
                    right = index;
                }
                else if (index == searchedIndex)
                {
                    Console.WriteLine("Number on index is: {0}", numbers[index]);
                    break;
                }
            }

        }

        static int MidPoint(int a, int b)
        {
            return (a + b) / 2;
        }
    }
}
