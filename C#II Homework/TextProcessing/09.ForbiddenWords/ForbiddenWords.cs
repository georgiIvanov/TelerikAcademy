using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _09.ForbiddenWords
{
    class ForbiddenWords
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string inputText = Console.ReadLine();
            Console.WriteLine("Enter forbidden words: ");
            string forbiddenWordsLine = Console.ReadLine();
            string[] forbWords = Regex.Split(forbiddenWordsLine, ", ");

            foreach (var word in forbWords)
            {
                inputText = inputText.Replace(word, new string('*', word.Length));
            }
            Console.WriteLine(inputText);
        }
    }
}
