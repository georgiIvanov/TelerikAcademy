using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PermutationWithRepetition
{
    class PermutationWithRepetition
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            int[] numbers = { 1, 3, 5, 5 };
            PermutationsWithRepetition(numbers);
        }

        static void PermutationsWithRepetition(int[] numbersSet)
        {
            Array.Sort(numbersSet);
            Permute(numbersSet, 0, numbersSet.Length);
        }

        static void Permute(int[] numbersSet, int start, int end)
        {
            PrintNumbers(numbersSet);

            int swapValue = 0;

            if (start < end)
            {
                for (int i = end - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < end; j++)
                    {
                        if (numbersSet[i] != numbersSet[j])
                        {
                            swapValue = numbersSet[i];
                            numbersSet[i] = numbersSet[j];
                            numbersSet[j] = swapValue;

                            Permute(numbersSet, i + 1, end);
                        }
                    }

                    swapValue = numbersSet[i];
                    for (int k = i; k < end - 1; k++)
                    {
                        numbersSet[k] = numbersSet[k + 1];
                    }
                    numbersSet[end - 1] = swapValue;
                }
            }
        }

        static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
