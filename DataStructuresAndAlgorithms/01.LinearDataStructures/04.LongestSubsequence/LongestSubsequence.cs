using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AverageSum;

namespace LongestSubsequenceProgram
{
    public class LongestSubsequence
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> 
            { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            List<int> subSequence = FindLongestSubsequence(numbers);

            IOOperations.PrintNumbers(subSequence);
        }

        public static List<int> FindLongestSubsequence(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                throw new InvalidOperationException("List must have numbers in it.");
            }

            List<int> subSequence = new List<int>();
            int currentNumber = numbers[0],
                sequenceCount = 0,
                maxCount = 0,
                sequenceOf = 0;

            foreach (var number in numbers)
            {
                if (number == currentNumber)
                {
                    sequenceCount++;
                }
                else
                {
                    sequenceCount = 1;
                    currentNumber = number;
                }

                if (sequenceCount > maxCount)
                {
                    maxCount = sequenceCount;
                    sequenceOf = currentNumber;
                }
            }

            subSequence = Enumerable.Repeat(sequenceOf, maxCount).ToList();
            return subSequence;
        }
    }
}
