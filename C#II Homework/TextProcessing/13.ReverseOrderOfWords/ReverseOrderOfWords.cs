using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _13.ReverseOrderOfWords
{
    class ReverseOrderOfWords
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            

            string regex = @"\s+|,\s*|\.\s*|!\s*|$";
            Stack<string> wordsStack = new Stack<string>();
            string[] words = Regex.Split(inputText, regex);

            foreach (var word in words)
            {
                if (!String.IsNullOrEmpty(word)) wordsStack.Push(word);
            }

            MatchCollection matches = Regex.Matches(inputText, regex);

            for (int i = 0; i < matches.Count - 1; i++)
            {
                Console.Write(wordsStack.Pop() + matches[i]);
            }

            Console.WriteLine();
        }
    }
}
