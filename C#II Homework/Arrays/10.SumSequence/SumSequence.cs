using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.SumSequence
{
    class SumSequence
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sum S: ");
            int targetSum = int.Parse(Console.ReadLine());
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            int[] numbers = new int[nSize];

            Console.WriteLine("Enter {0} numbers: ", nSize);
            for (int i = 0; i < nSize; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int currentSum = 0;
            for (int i = 0, j = 0; i < nSize; i++)
            {
                currentSum = 0;
                for (j = i; j < nSize; j++)
                {
                    currentSum += numbers[j];
                    if (currentSum >= targetSum)
                    {
                        break;
                    }
                }
                if (currentSum == targetSum)
                {
                    Console.WriteLine("Sequence equal to sum : ");
                    j = i;
                    while (currentSum != 0)
                    {
                        
                        Console.Write("{0} ", numbers[j]);
                        currentSum -= numbers[j];
                        j++;
                    }
                    Console.WriteLine();
                    break;
                }
            }

            if (currentSum != 0)
            {
                Console.WriteLine("No sum found");
            }


        }
    }
}
