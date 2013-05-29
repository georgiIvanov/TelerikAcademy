using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AverageSum;

namespace _05.RemoveNegative
{
    class RemoveNegative
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>
            { 1, -2, 3, -4, 5, -6, 7, -8 };

            List<int> positiveNumbers = (from number in numbers
                                         where number > 0
                                         select number).ToList();

            IOOperations.PrintNumbers(positiveNumbers);
        }
    }
}
