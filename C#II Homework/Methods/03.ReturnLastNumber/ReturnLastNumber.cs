using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ReturnLastNumber
{
    class ReturnLastNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(ReturnLastNumberAsString(number));
        }

        static string ReturnLastNumberAsString(int num)
        {
            if (num < 0) num *= -1;
            int lastNum = num % 10;
            string word = "";
            switch (lastNum)
            {
                case 1: word = "One"; break;
                case 2: word = "Two"; break;
                case 3: word = "Three"; break;
                case 4: word = "Four"; break;
                case 5: word = "Five"; break;
                case 6: word = "Six"; break;
                case 7: word = "Seven"; break;
                case 8: word = "Eight"; break;
                case 9: word = "Nine"; break;
                case 0: word = "Zero"; break;
            }

            return word;
        }
    }
}
