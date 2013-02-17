using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _20.ExtractPalindromes
{
    class ExtractPalindromes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string inputString = Console.ReadLine();

            foreach (Match item in Regex.Matches(inputString, @"\w+"))
            {
                if(CheckPalindrome(item.ToString()))
                {
                    Console.WriteLine(item);
                }
            }
        }

        static bool CheckPalindrome(string input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
