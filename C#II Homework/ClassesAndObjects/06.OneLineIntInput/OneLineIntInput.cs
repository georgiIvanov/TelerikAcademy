using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.OneLineIntInput
{
    class OneLineIntInput
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter strings on line: ");
            string inputLine = Console.ReadLine();
            string[] strings = inputLine.Split();

            int[] numbers = new int[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                numbers[i] = int.Parse(strings[i]);
            }

            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("Result: {0}", sum);
            

        }
    }
}
