using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ReturnBiggerNumber
{
    class ReturnBiggerNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            Console.WriteLine("Enter 3 numbers: ");
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int biggest = GetMax(numbers[0], numbers[1]);
            biggest = GetMax(biggest, numbers[2]);

            Console.WriteLine("Biggest number is: {0}", biggest);
            
        }

        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else if (a < b)
            {
                return b;
            }
            return a;
        }
    }
}
