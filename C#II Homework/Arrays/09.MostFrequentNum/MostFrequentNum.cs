using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.MostFrequentNum
{
    class MostFrequentNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            int[] numbers = new int[nSize];
            int biggest = int.MinValue;
            int smallest = int.MaxValue;

            Console.WriteLine("Enter {0} numbers: ", nSize);
            for (int i = 0; i < nSize; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());

                if (numbers[i] >= biggest)
                {
                    biggest = numbers[i];
                }
                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                }
            }

            int mostFreq = 0, freq = 0, mostFNumber = 0;
            for (int num = smallest; num < biggest; num++)
            {
                freq = 0;
                for (int j = 0; j < nSize; j++)
                {
                    if (numbers[j] == num)
                    {
                        freq++;
                    }
                }

                if (freq > mostFreq)
                {
                    mostFNumber = num;
                    mostFreq = freq;
                }
            }

            Console.WriteLine("Most frequent number {0}({1} times)", mostFNumber, mostFreq);



        }
    }
}
