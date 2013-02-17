using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.CheckIfPrime
{
    class CheckIfPrime
    {
        static void Main(string[] args)
        {
            int number = new int();

            do
            {
                number = int.Parse(Console.ReadLine());
            }
            while (number > 100);

            bool notPrime = false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    notPrime = true;
                }
            }

            if (!notPrime)
            {
                Console.WriteLine("Number is prime");
            }
            else
            {
                Console.WriteLine("Number is not prime");
            }

        }
    }
}
