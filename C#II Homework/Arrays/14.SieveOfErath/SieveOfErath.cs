using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14.SieveOfErath
{
    class SieveOfErath
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10000001];
            int multiplier = 2;

            for (int i = 2; i < 10000001; i++)
            {
                if (numbers[i] == 0)
                {
                    multiplier = 2;
                    while (i * multiplier < 10000001)
                    {
                        numbers[i * multiplier] = 1;
                        multiplier++;
                    }
                }
            }

            for (int i = 0; i < 10000001; i++)
            {
                if (numbers[i] == 0)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
