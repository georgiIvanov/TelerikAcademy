using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OccuranceOfValues
{
    class OccuranceOfValues
    {
        static void Main(string[] args)
        {
            double[] numbers = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, double> occurance = new Dictionary<double, double>();

            foreach (var number in numbers)
            {
                if (occurance.ContainsKey(number))
                {
                    occurance[number] += 1;
                }
                else
                {
                    occurance.Add(number, 1);
                }
            }

            foreach (var entry in occurance)
            {
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);
            }
        }
    }
}
