using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.BiggestNumber
{
    class BiggestNumber
    {
        static void Main(string[] args)
        {
            double[] numbers = new double[5];
            double maxNum = 0;

            for (int i = 0; i < 5; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
                if (numbers[i] > maxNum)
                {
                    maxNum = numbers[i];
                }
            }
            Console.WriteLine("Biggest number: " + maxNum);
        }
    }
}
