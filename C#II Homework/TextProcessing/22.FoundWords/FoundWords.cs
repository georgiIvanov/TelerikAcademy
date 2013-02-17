using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _22.FoundWords
{
    class FoundWords
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text: ");
            string inputText = Console.ReadLine();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (Match match in Regex.Matches(inputText, @"\w+"))
            {
                if (dict.ContainsKey(match.Value))
                {
                    dict[match.Value] = dict[match.Value] + 1;
                }
                else
                {
                    dict.Add(match.Value, 1);
                }
            }

            foreach (var elem in dict)
            {
                Console.WriteLine("{0} {1}", elem.Key, elem.Value);
            }

        }
    }
}
