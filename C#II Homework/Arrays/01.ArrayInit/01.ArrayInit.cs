using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ArrayInit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[20];

            for (int i = 0; i < 20; i++)
			{
                numbers[i] = i * 5;
			}

            for (int i = 0; i < 20; i++)
			{
                Console.WriteLine(numbers[i]);
			}



        }
    }
}
