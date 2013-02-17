using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _24.PrintInOrder
{
    class PrintInOrder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter words: ");
            string inputWords = Console.ReadLine();
            List<string> sortedWords = new List<string>();

            foreach (Match match in Regex.Matches(inputWords, @"\w+"))
            {
                sortedWords.Add(match.Value.ToLower());
            }

            sortedWords.Sort();
            foreach (var item in sortedWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
