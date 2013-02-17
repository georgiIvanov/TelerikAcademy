using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _21.WordInformation
{
    class WordInformation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string inputText = Console.ReadLine();

            Dictionary<char, int> charDict = new Dictionary<char, int>();
            List<string> words = new List<string>();
            int tempValue = 0;

            foreach (Match item in Regex.Matches(inputText, @"\w+"))
            {
                foreach (char ch in item.ToString().ToLower())
                {
                    if (!charDict.ContainsKey(ch))
                    {
                        charDict.Add(ch, 1);
                    }
                    else
                    {
                        charDict.TryGetValue(ch, out tempValue);
                        tempValue++;
                        charDict.Remove(ch);
                        charDict.Add(ch, tempValue);
                    }
                }
            }

            Console.WriteLine("Number different letters: {0}", charDict.Count);
            foreach (var word in charDict)
            {
                Console.WriteLine("Char {0}: {1}", word.Key, word.Value);
            }
        }
    }
}
