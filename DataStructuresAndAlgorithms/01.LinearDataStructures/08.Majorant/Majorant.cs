using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Majorant
{
    class Majorant
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> 
            { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            int majorant;
            if (TryFindMajorant(numbers, out majorant))
            {
                Console.WriteLine("Majorant: {0}",majorant);
            }
            else
            {
                Console.WriteLine("No majorant exists.");
            }

        }

        private static bool TryFindMajorant(List<int> numbers, out int majorant)
        {
            Dictionary<int, int> numbersRepetition = new Dictionary<int, int>();
            majorant = 0;

            foreach (var number in numbers)
            {
                if (numbersRepetition.ContainsKey(number))
                {
                    numbersRepetition[number] += 1;
                }
                else
                {
                    numbersRepetition.Add(number, 1);
                }
            }

            int neededCount = numbers.Count / 2 + 1;
            foreach (var pair in numbersRepetition)
            {
                if (pair.Value >= neededCount)
                {
                    majorant = pair.Key;
                    return true;
                }
            }

            return false;
        }
    }
}
