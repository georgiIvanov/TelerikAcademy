using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordOccurance
{
    class TrieNode
    {
        int words;
        int prefixes;
        TrieNode[] edges;

        public TrieNode()
        {
            this.edges = new TrieNode[26];
            this.Words = 0;
            this.Prefixes = 0;
        }

        public TrieNode AddWord(TrieNode node, string word)
        {
            return this.AddWord(node, word, 0);
        }

        public int CountWords(TrieNode node, string word)
        {
            return this.CountWords(node, word, 0);
        }

        public int CountPrefix(TrieNode node, string word)
        {
            return this.CountPrefix(node, word, 0);
        }

        public int Words
        {
            get
            {
                return this.words;
            }
            set
            {
                this.words = value;
            }
        }

        public int Prefixes
        {
            get
            {
                return this.prefixes;
            }
            set
            {
                this.prefixes = value;
            }
        }

        private TrieNode AddWord(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                node.Words += 1;
            }
            else
            {
                node.Prefixes += 1;
                
                int index = word[indexInWord] - 'a';
                indexInWord++;

                if (node.edges[index] == null)
                {
                    node.edges[index] = new TrieNode();
                }

                node.edges[index] = AddWord(node.edges[index], word, indexInWord);
            }

            return node;
        }

        private int CountWords(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                return node.words;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - 'a';
                indexInWord++;
                if (node.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return CountWords(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }

        private int CountPrefix(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                return node.prefixes;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - 'a';
                indexInWord++;
                if (node.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return CountPrefix(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }

    }
}
