using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _23.ReplaceConsecutiveLetters
{
    class ReplaceConsecutiveLetters
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");
            string inputString = Console.ReadLine();

            Console.WriteLine(Regex.Replace(inputString, @"(\w)\1+", "$1"));


        }
    }
}
