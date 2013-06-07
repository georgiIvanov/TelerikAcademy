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
            var words = SetInputText();


            PopulateDictionary(sw, words, wordsInDictionary);

            //takes about 9 secs
            PopulateTrie(sw, start, words);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Word: {0}", words[i].ToString());


                SearchInTrie(sw, start, words, words[i].ToString());

                SearchInDictionary(sw, wordsInDictionary, words, words[i].ToString());
            }
        }

        private static void SearchInTrie(Stopwatch sw, TrieNode start, MatchCollection words, string searchedWord)
        {
            int wordCount = 0;
            sw.Restart();
            wordCount = start.CountWords(start, searchedWord);
            sw.Stop();

            Console.WriteLine("Times word found: {0}", wordCount);
            Console.WriteLine("Time in searching trie: {0}", sw.Elapsed);
        }

        private static void PopulateTrie(Stopwatch sw, TrieNode start, MatchCollection words)
        {
            sw.Start();
            foreach (var item in words)
            {
                start.AddWord(start, item.ToString());
            }
            sw.Stop();
            Console.WriteLine("Time to populate the trie: {0}\n", sw.Elapsed);
        }

        private static void SearchInDictionary(Stopwatch sw, Dictionary<string, int> wordsInDictionary, MatchCollection words, string searchedWord)
        {
            int wordCount = 0;
            sw.Restart();
            wordCount = wordsInDictionary[searchedWord];
            sw.Stop();

            Console.WriteLine("Times word found: {0}", wordCount);
            Console.WriteLine("Time in searching dictionary: {0}\n", sw.Elapsed);
        }

        private static void PopulateDictionary(Stopwatch sw, MatchCollection words, Dictionary<string, int> wordsInDictionary)
        {
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