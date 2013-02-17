using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.SignOfProduct
{
    class SignOfProduct
    {
        static int Main(string[] args)
        {
            double[] numbers = new double[3];

            for (int i = 0; i < 3; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
            }

            bool isNegative = false;
            foreach (var item in numbers)
            {
                if (item < 0)
                {
                    isNegative = !isNegative;
                }
                else if (item == 0)
                {
                    Console.WriteLine("Product is 0");
                    return 0;
                }
            }

            if (isNegative)
            {
                Console.WriteLine("Product is negative");
            }
            else
            {
                Console.WriteLine("Product is positive");
            }
            return 0;
        }
    }
}
