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
            Dictionary<string, int> wordsInDictionary = new Dictionary<string, int>();
            var allWords = SetInputText();

            List<string> wordsToSearch = new List<string>();
            // change number to increase searched words count
            for (int i = 0; i < 50; i++)
            {
                wordsToSearch.Add(allWords[i].ToString());
            }

            AddWordsForSearchInDictionary(sw, wordsToSearch, wordsInDictionary);
            AddWordsForSearchInTrie(sw, start, wordsToSearch);

            IncrementOccuranceCountTrie(sw, start, allWords);
            IncrementOccuranceCountDictionary(sw, wordsInDictionary, allWords);
            

            Console.WriteLine("Searched words count trie: ");
            foreach (var word in wordsToSearch)
            {
                Console.WriteLine("{0}: {1}", word, start.CountWords(start, word));
            }


            Console.WriteLine("\nSearched words count dictionary: ");
            foreach (var item in wordsInDictionary)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }

        private static void IncrementOccuranceCountTrie(Stopwatch sw, TrieNode start, MatchCollection allWords)
        {
            sw.Restart();
            foreach (var word in allWords)
            {
                start.AddOccuranceIfExists(start, word.ToString());
            }
            
            sw.Stop();
            Console.WriteLine("Adding searched words count trie for: {0}", sw.Elapsed);
        }

        private static void IncrementOccuranceCountDictionary(Stopwatch sw, Dictionary<string, int> wordsInDictionary, MatchCollection allWords)
        {
            sw.Restart();
            foreach (var word in allWords)
            {
                string wordStr = word.ToString();
                if (wordsInDictionary.ContainsKey(wordStr))
                {
                    wordsInDictionary[wordStr] += 1;
                }
            }
            
            sw.Stop();

            Console.WriteLine("Adding searched words count dictionary for: {0}\n", sw.Elapsed);
        }

        private static void AddWordsForSearchInTrie(Stopwatch sw, TrieNode start, List<string> words)
        {
            sw.Start();
            foreach (var item in words)
            {
                start.AddWord(start, item.ToString());
            }
            sw.Stop();
            Console.WriteLine("Time to populate the trie: {0}\n", sw.Elapsed);
        }

        private static void AddWordsForSearchInDictionary(Stopwatch sw, List<string> words, Dictionary<string, int> wordsInDictionary)
        {
            sw.Restart();
            foreach (var item in words)
            {
                string word = item.ToString();
                if (!wordsInDictionary.ContainsKey(word))
                {
                    wordsInDictionary[word] = 0;
                }
            }
            sw.Stop();
            Console.WriteLine("Time to populate dictionary: {0}\n\n", sw.Elapsed);
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
