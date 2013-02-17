using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.BiggestElementFromIndex
{
    class BiggestElementFromIndex
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());
            int index = -1;
            while(index < 0 || index >= n)
            {
                Console.WriteLine("Enter index from which the search starts: ");
                index = int.Parse(Console.ReadLine());
            }
            int[] numbers = new int[n];
            Console.WriteLine("Enter {0} numbers, each on new line: ", n);
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Biggest element: ");
            Console.WriteLine(BiggestElemInArray(numbers, index, false));

            Console.WriteLine();
            Console.WriteLine("Sorting the input array: ");
            int[] sorted = new int[n];
            Array.Copy(numbers, sorted, n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(BiggestElemInArray(numbers, 0, true));
            }
            
        }

        static int BiggestElemInArray(int[] numbers, int index, bool deleteElement)
        {
            int biggest = int.MinValue, indexOfNumber = 0;


            for (int i = index; i < numbers.Length; i++)
            {
                if (numbers[i] > biggest)
                {
                    biggest = numbers[i];
                    indexOfNumber = i;
                }
            }
            if (deleteElement)
            {
                numbers[indexOfNumber] = 0;
            }
            return biggest;
        }
    }
}
