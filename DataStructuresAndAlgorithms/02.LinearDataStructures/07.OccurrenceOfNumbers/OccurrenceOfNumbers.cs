using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.OccurrenceOfNumbers
{
    class OccurrenceOfNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            Dictionary<int, int> occurance = FindOccurrence(numbers);

            PrintDictionary(occurance);

        }

        private static Dictionary<int, int> FindOccurrence(List<int> numbers)
        {
            Dictionary<int, int> occuranceOfNumbers = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (occuranceOfNumbers.ContainsKey(number))
                {
                    occuranceOfNumbers[number] += 1;
                }
                else
                {
                    occuranceOfNumbers.Add(number, 1);
                }
            }

            return occuranceOfNumbers;
        }

        private static void PrintDictionary(Dictionary<int, int> occurance)
        {
            foreach (var pair in occurance)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }

        }
    }
}
