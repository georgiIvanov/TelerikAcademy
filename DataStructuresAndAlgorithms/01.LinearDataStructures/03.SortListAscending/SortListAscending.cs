using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AverageSum;

namespace _03.SortListAscending
{
    class SortListAscending
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            IOOperations.GetNumbers(numbers);

            // another way
            // numbers.Sort();

            numbers = (from number in numbers
                       orderby number ascending
                       select number).ToList();

            IOOperations.PrintNumbers(numbers);
        }
    }
}
