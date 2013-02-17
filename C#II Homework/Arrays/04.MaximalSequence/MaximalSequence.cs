using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MaximalSequence
{
    class MaximalSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length of sequence: ");
            int seqL = int.Parse(Console.ReadLine());

            int[] sequence = new int[seqL];
            int currentNum = int.MinValue, maxL = 0, biggestMaxL = int.MinValue, numInSeq = 0;

            Console.WriteLine("Enter {0} numbers", seqL);

            for (int i = 0; i < seqL; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < seqL; i++)
            {
                if (sequence[i] == currentNum)
                {
                    maxL++;
                    if (maxL > biggestMaxL)
                    {
                        biggestMaxL = maxL;
                        numInSeq = sequence[i];
                    }
                }
                else
                {
                    currentNum = sequence[i];
                    maxL = 1;
                }
            }

            if (biggestMaxL == int.MinValue)
            {
                Console.WriteLine("No sub sequence found");
            }
            else
            {
                Console.WriteLine("Longest sequence is {0}, of {1}", biggestMaxL, numInSeq);
            }

        }
    }
}
