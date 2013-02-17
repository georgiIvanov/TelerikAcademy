using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ReadAndReverse
{
    class ReadAndReverse
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] toChar = input.ToCharArray();

            Array.Reverse(toChar);

            StringBuilder sb = new StringBuilder();

            foreach (var ch in toChar)
            {
                sb.Append(ch);
            }
            Console.WriteLine(sb.ToString());

        }
    }
}
