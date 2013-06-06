using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.OddElements
{
    class OddElements
    {
        static void Main(string[] args)
        {
            string[] words = {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, int> wordsOccurance = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordsOccurance.ContainsKey(word))
                {
                    wordsOccurance[word] += 1;
                }
                else
                {
                    wordsOccurance.Add(word, 1);
                }
            }

            List<string> oddWordsCount = new List<string>();
            foreach (var entry in wordsOccurance)
            {
                if ((entry.Value & 1) > 0)
                {
                    oddWordsCount.Add(entry.Key);
                }
            }

            foreach (var word in oddWordsCount)
            {
                Console.WriteLine("{0}", word);
            }
        }
    }
}
