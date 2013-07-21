using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace _01.MongoDictionary
{
    class Program
    {
        static MongoDictionary<Word> mongoDictionary;

        static void Main(string[] args)
        {
            mongoDictionary = new MongoDictionary<Word>("collection", "collection");

            string[] command = { " " };
            while (command[0] != "end")
            {
                PrintMenu();
                command = Console.ReadLine().Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "add": AddWord(command[1], JoinTranslation(command, 2)); break;
                    case "translate": Translate(command[1]); break;
                    case "list": ListAllWords(); break;
                    case "end": break;
                }
            }
        }

        private static void ListAllWords()
        {
            var list = mongoDictionary.GetHashObjects();

            foreach (var item in list)
            {
                Console.WriteLine("{0} - {1}", item.GetWord, item.GetTranslation);
            }
        }

        static string JoinTranslation(string[] toJoin, int startIndex)
        {
            StringBuilder joined = new StringBuilder();
            for (int i = startIndex; i < toJoin.Length; i++)
            {
                joined.AppendFormat("{0} ", toJoin[i]);
            }
            joined.Length--;
            return joined.ToString();
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n\n\nCommands: add [word] [translation], translate [word], list, end\n\n");
        }

        static void AddWord(string word, string translation)
        {
            Word newWord = new Word(word, translation);
            mongoDictionary.StoreInHash(newWord);
        }

        private static void Translate(string word)
        {
            var found = mongoDictionary.GetFromHash(word);
            Console.WriteLine("{0}", found.GetTranslation);
        }
    }
}
