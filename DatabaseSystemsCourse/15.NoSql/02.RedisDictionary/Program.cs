using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _02.RedisDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Dont forget to run redis server
            ///

            string[] command = {" "};
            while (command[0] != "end")
            {
                PrintMenu();
                command = Console.ReadLine().Split(
                    new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                
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
            var list = RedisDbActions.GetKeysAndValues();

            foreach (var item in list)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
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
            RedisDbActions.StoreInHash(word, translation);
        }

        private static void Translate(string word)
        {
            Console.WriteLine("Translation: {0}", RedisDbActions.GetValue(word));
        }
    }
}
