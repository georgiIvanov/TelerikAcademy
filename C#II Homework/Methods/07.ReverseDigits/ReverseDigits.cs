using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.ReverseDigits
{
    class ReverseDigits
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number: ");
            string number = Console.ReadLine();
            Console.WriteLine(NumberReverse(number));

        }

        static string NumberReverse(string numStr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                sb.Append(numStr[i]);
            }

            return sb.ToString();
        }
    }
}
