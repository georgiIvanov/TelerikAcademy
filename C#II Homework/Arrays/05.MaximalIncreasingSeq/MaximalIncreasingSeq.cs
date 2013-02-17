using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.MaximalIncreasingSeq
{
    class MaximalIncreasingSeq
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length of sequence: ");
            int seqL = int.Parse(Console.ReadLine());
            int subSeqL = int.MaxValue;

            while (subSeqL >= seqL) 
            {
                Console.WriteLine("Enter length of increasing sequence to be searched: ");
                subSeqL = int.Parse(Console.ReadLine());
            }

            int[] sequence = new int[seqL];
            int maxL = 0, indexMaxL = int.MinValue;

            Console.WriteLine("Enter {0} numbers", seqL);

            for (int i = 0; i < seqL; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i <= seqL - subSeqL; i++)
            {
                SearchForBiggestSubSeq(sequence, subSeqL, i, ref indexMaxL, ref maxL);
            }

            Console.WriteLine("Biggest sequence is: ");
            for (int i = indexMaxL; i < indexMaxL + subSeqL; i++)
            {
                Console.Write("{0} ", sequence[i]);
            }

        }

        /// <summary>
        /// finds last biggest sequence
        /// </summary>
        static void SearchForBiggestSubSeq(int[] sequence, int subSeqL, int startingIndex, ref int indexOfMaxSeq, ref int maxL)
        {
            int currentNum = sequence[startingIndex];
            int lenOfCurrentSeq = 1;

            for (int i = startingIndex+1; i < subSeqL + startingIndex; i++)
            {
                if (currentNum < sequence[i])
                {
                    currentNum = sequence[i];
                    lenOfCurrentSeq++;
                }
                else
                {
                    break;
                }
            }

            if (lenOfCurrentSeq >= maxL)
            {
                maxL = lenOfCurrentSeq;
                indexOfMaxSeq = startingIndex;
            }
        }
    }
}
