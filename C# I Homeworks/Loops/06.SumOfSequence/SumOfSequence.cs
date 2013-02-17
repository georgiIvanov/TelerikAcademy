using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.SumOfSequence
{
    class SumOfSequence
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());

            double s = 1, //sum of sequence
                fact = 1;
            //loop for members of the sequence
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    fact *= j;
                }
                s += fact / Math.Pow(x, i);
                fact = 1;
            }

            Console.WriteLine(s);


        }
    }
}
