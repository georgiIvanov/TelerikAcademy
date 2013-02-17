using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.SumOfSequence
{
    class SumOfSequence
    {
        static void Main(string[] args)
        {
            double n = 0, sum = 1, i = 2;

            do
            {
                n = 1 / i;
                sum += n;
                i++;

            } while (n > 0.001);

            Console.WriteLine(sum);
        }
    }
}
