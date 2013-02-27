using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DivisibleBy7And3
{
    class DivisibleBy7And3
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 42, 49, 21, 63, 189 };

            var divisible = numbers.Where(x => x % 3 == 0 && x % 7 == 0);

            foreach (var item in divisible)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var divisible2 = from num in numbers
                             where num % 3 == 0 && num % 7 == 0
                             select num;

            foreach (var item in divisible2)
            {
                Console.WriteLine(item);
            }

        }
    }
}
