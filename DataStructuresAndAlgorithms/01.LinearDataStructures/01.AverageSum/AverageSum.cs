using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageSum
{
    class AverageSum
    {
        static void Main(string[] args)
        {
            
            List<int> numbers = new List<int>();

            IOOperations.GetNumbers(numbers);

            double average = numbers.Average();

            Console.WriteLine(average);
        }

        
    }
}
