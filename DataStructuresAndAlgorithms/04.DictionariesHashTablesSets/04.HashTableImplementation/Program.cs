using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
    class Program
    {
        static void Main()
        {
            HashTable<string, string> hashTable = new HashTable<string, string>();
            hashTable.Add("1", "aa1");
            hashTable.Add("2", "22a");
            hashTable.Add("3", "wwer");
            hashTable.Add("4", "rrrr");
            hashTable.Add("5", "qqqq");
            hashTable.Add("6", "tttt");

            Console.WriteLine(hashTable.Find("2"));
            Console.WriteLine("Count: {0}", hashTable.Count);

            hashTable.Remove("1");
            Console.WriteLine("Count: {0}", hashTable.Count);
            Console.WriteLine(hashTable["3"]);

            Console.WriteLine("\nKeys: ");
            foreach (var item in hashTable.Keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nIteration with foreach:");
            foreach (var item in hashTable)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }

        }
    }
}