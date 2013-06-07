using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _03.WordOccurance
{
    class WordOccurance
    {
        static void Main(string[] args)
        {
            ///===========================================
            ///Unzip the archive in the project directory
            ///===========================================
            
            Stopwatch sw = new Stopwatch();
            TrieNode start = new TrieNode();
            var words = SetInputText();
            
            //takes about 9 secs
            SearchInTrie(sw, start, words, "again");

            SearchInDictionary(sw, words, "again");
        }

        private static void SearchInTrie(Stopwatch sw, TrieNode start, MatchCollection words, string searchedWord)
        {
            int wordCount = 0;
            sw.Start();
            foreach (var item in words)
            {
                start.AddWord(start, item.ToString());
            }
            sw.Stop();
            Console.WriteLine("Time to populate the trie: {0}", sw.Elapsed);


            sw.Restart();
            wordCount = start.CountWords(start, searchedWord);
            sw.Stop();

            Console.WriteLine("Times word found: {0}", wordCount);
            Console.WriteLine("Elapsed time in searching: {0}", sw.Elapsed);
        }

        private static void SearchInDictionary(Stopwatch sw, MatchCollection words, string searchedWord)
        {
            int wordCount = 0;
            Dictionary<string, int> wordsInDictionary = new Dictionary<string, int>();

            sw.Restart();
            foreach (var item in words)
            {
                string word = item.ToString();
                if (wordsInDictionary.ContainsKey(word))
                {
                    wordsInDictionary[word] += 1;
                }
                else
                {
                    wordsInDictionary[word] = 1;
                }
            }
            sw.Stop();
            Console.WriteLine("\n\nTime to populate dictionary: {0}", sw.Elapsed);

            sw.Restart();
            wordCount = wordsInDictionary[searchedWord];
            sw.Stop();

            Console.WriteLine("Times word found: {0}", wordCount);
            Console.WriteLine("Elapsed time in searching: {0}", sw.Elapsed);
        }

        static MatchCollection SetInputText()
        {
            ///===========================================
            ///Unzip the archive in the project directory
            ///===========================================
            string inputText;
            StreamReader sr = new StreamReader("..\\..\\text.txt");
            using (sr)
            {
                inputText = sr.ReadToEnd().ToLower();
            }

            var matches = Regex.Matches(inputText, @"[a-zA-Z]+");
            return matches;
        }
    }
}
