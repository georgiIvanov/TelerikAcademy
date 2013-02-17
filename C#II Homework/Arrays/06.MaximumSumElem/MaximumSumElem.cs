using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.MaximumSumElem
{
    class MaximumSumElem
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            int k = int.MaxValue;
            int kMaxNum = int.MinValue;

            while (k >= n || k <= 0)
            {
                Console.Write("Enter k: ");
                k = int.Parse(Console.ReadLine());
            }

            int[] numArray = new int[n];

            Console.WriteLine("Enter {0} numbers: ", n);
            for (int i = 0; i < n; i++)
            {
                numArray[i] = int.Parse(Console.ReadLine());
                if (numArray[i] > kMaxNum)
                {
                    kMaxNum = numArray[i];
                }
            }

            int kSum = 0, kIndex = 0;
            int[] kArray = new int[k];

            for (int nextKNum = kMaxNum; nextKNum >= 0; nextKNum--)
            {
                if (kIndex == k)
                    break;
                for (int i = 0; i < n; i++)
                {
                    if (numArray[i] == nextKNum)
                    {
                        kArray[kIndex] = nextKNum;
                        kIndex++;
                        kSum += nextKNum;
                    }
                    
                }
            }

            Console.WriteLine("Maximum sum is {0}", kSum);
            Console.Write("Numbers are: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write("{0} ", kArray[i]);
            }
            Console.WriteLine();

        }
    }
}
