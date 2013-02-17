using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14.DictionaryImplementation
{
    class DictionaryImplementation
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add(".NET", "platform for applications from Microsoft");
            dict.Add("CLR", "managed execution enviroment for .NET");
            dict.Add("namespace", "hierarchical organization of classes");

            Console.WriteLine("Enter word for search: ");
            string sWord = Console.ReadLine();
            string result;
            if (dict.TryGetValue(sWord, out result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No such word");
            }

        }
    }
}
