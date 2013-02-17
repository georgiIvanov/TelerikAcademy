using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.SelectionSort
{
    class SelectionSort
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            int[] numbers = new int[nSize];
            int smallest = int.MaxValue;
            int biggest = int.MinValue;

            Console.WriteLine("Enter {0} numbers: ", nSize);

            for (int i = 0; i < nSize; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                }
                else if (numbers[i] >= biggest)
                {
                    biggest = numbers[i];
                }
            }

            int orderedIndex = 0, temp;

            for (int num = smallest; num < biggest; num++)
            {
                for (int j = 0; j < nSize; j++)
                {
                    if (num == numbers[j])
                    {
                        temp = numbers[orderedIndex];
                        numbers[orderedIndex] = num;
                        numbers[j] = temp;
                        orderedIndex++;
                    }
                }
            }

            Console.WriteLine("Ordered: ");
            for (int i = 0; i < nSize; i++)
            {
                Console.WriteLine(numbers[i]);
            }


        }
    }
}
