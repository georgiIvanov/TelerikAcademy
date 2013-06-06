using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _03.WordsCount
{
    class WordsCount
    {
        static void Main(string[] args)
        {
            var matches = GetWords();

            Dictionary<string, int> wordOccurance = new Dictionary<string, int>();

            foreach (var word in matches)
            {
                string strWord = word.ToString();
                if (wordOccurance.ContainsKey(strWord))
                {
                    wordOccurance[strWord] += 1;
                }
                else
                {
                    wordOccurance.Add(strWord, 1);
                }
            }

            List<KeyValuePair<string, int>> wordPairs = wordOccurance.ToList();
            wordPairs.Sort((x, y) => x.Value.CompareTo(y.Value));

            foreach (var entry in wordPairs)
            {
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);
            }

        }

        private static MatchCollection GetWords()
        {
            StreamReader sr = new StreamReader("..\\..\\text.txt");
            string text;
            using (sr)
            {
                text = sr.ReadToEnd().ToLower();
            }

            var matches = Regex.Matches(text, @"\w+");
            return matches;
        }
    }
}
