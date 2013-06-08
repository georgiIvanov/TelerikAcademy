using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionaryImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            BiDictionary<int, string, string> biDictionary = new BiDictionary<int, string, string>();

            for (int i = 0; i < 10; i++)
            {
                biDictionary.Add(i, i.ToString(), string.Format("entry{0}", i));
            }

            ICollection<string> found;

            biDictionary.Add(0, "0", "duplicatedEntry0");
            found = biDictionary.FindUsingFirstKey(0);
            PrintCollection<string>(found);

            biDictionary.Add(1, "2", "duplicateInThreeDictionaries");
            found = biDictionary.FindUsingBothKeys(1, "2");
            PrintCollection(found);

            found = biDictionary.FindUsingBothKeys(5, "5");
            PrintCollection(found);

            biDictionary.Add(100, "99", "only value for those keys");
            PrintCollection(biDictionary.FindUsingFirstKey(100));
            PrintCollection(biDictionary.FindUsingSecondKey("99"));


            biDictionary.RemoveWithFirstKey(1);
            found = biDictionary.FindUsingFirstKey(1);
            Console.WriteLine("Found items after removing with first key: {0}", found.Count > 0);

            
            biDictionary.RemoveWithSecondKey("0");
            found = biDictionary.FindUsingSecondKey("0");
            Console.WriteLine("Found items after removing with second key: {0}", found.Count > 0);
            found = biDictionary.FindUsingFirstKey(0);
            Console.WriteLine("Found items with first key: {0}", found.Count > 0);

            biDictionary.RemoveWithBothKeys(100, "99");
            found = biDictionary.FindUsingBothKeys(100, "99");
            Console.WriteLine("Found items after removing with both keys: {0}", found.Count > 0);
        }

        private static void PrintCollection<V>(ICollection<V> found)
        {
            foreach (var item in found)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
        }
    }
}