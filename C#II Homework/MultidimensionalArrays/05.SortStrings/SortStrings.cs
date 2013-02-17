using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.SortStrings
{
    class SortStrings
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length of array: ");
            int n = int.Parse(Console.ReadLine());

            string[] strings = new string[n];

            Console.WriteLine("Enter {0} strings: ", n);
            for (int i = 0; i < n; i++)
            {
                strings[i] = Console.ReadLine();
            }

            SortStringsByLen(strings);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }

        static void SortStringsByLen(string[] str)
        {
            StrComp comparer = new StrComp();

            Array.Sort(str, comparer);
        }
    }

    class StrComp : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            if (x.Length > y.Length)
                return 1;
            else if (x.Length < y.Length)
                return -1;
            else
                return 0;
        }

    }
}
