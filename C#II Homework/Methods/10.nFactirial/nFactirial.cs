using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _10.nFactirial
{
    class nFactirial
    {
        static void Main(string[] args)
        {
            int number = 1;
            BigInteger numFactorial = number;

            for (int i = 1; i <= 100; i++)
            {
                number = i;
                numFactorial = 1;
                Console.Write("Number {0}: ", number);
                Console.WriteLine(CalculateFactorial(ref number, ref numFactorial)); 

            }
        }

        static string CalculateFactorial(ref int number, ref BigInteger numFactorial)
        {
            while (number > 0)
            {
                numFactorial *= number;
                number--;
            }

            return numFactorial.ToString();
        }
    }
}
