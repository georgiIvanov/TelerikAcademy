using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageSum
{
    public class IOOperations
    {
        public static void GetNumbers(List<int> numbers)
        {
            string input = null;
            while (input != "")
            {
                int number;
                input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    numbers.Add(number);
                }
            }
        }

        public static void PrintNumbers(List<int> list)
        {
            foreach (var number in list)
            {
                Console.WriteLine(number);
            }
        }
    }
}
