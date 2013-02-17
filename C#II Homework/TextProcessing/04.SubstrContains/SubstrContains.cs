using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SubstrContains
{
    class SubstrContains
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string input = Console.ReadLine();
            Console.Write("Enter substring for search: ");
            string substr = Console.ReadLine();
            int substrCount = 0;

            int index = 0;
            while (index != -1 + substr.Length)
            {
                index = input.IndexOf(substr, index) + substr.Length;
                substrCount++;
            }
            Console.WriteLine(substrCount);

        }
    }
}
