using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.MaxSumSequence
{
    class MaxSumSequence
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            int subSeqSize = int.MinValue;

            while (subSeqSize >= nSize || subSeqSize <= 1)
            {
                Console.Write("Enter size of subsequence: ");
                subSeqSize = int.Parse(Console.ReadLine());
            }
            
            int[] numbers = new int[nSize];

            Console.WriteLine("Enter {0} numbers: ", nSize);

            for (int i = 0; i < nSize; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }


            int subSum = 0, subSMaxSum = int.MinValue, subSIndex = 0;
            for (int i = 0; i <= nSize - subSeqSize; i++)
            {
                subSum = 0;
                for (int j = i; j < i +subSeqSize; j++)
                {
                    subSum += numbers[j];
                }
                if (subSum > subSMaxSum)
                {
                    subSMaxSum = subSum;
                    subSIndex = i;
                }
            }

            Console.WriteLine("Maximal sequence: ");
            for (int i = subSIndex; i < subSIndex + subSeqSize; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }

            Console.WriteLine();
        }
    }
}
