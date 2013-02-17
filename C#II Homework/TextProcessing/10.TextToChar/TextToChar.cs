using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.TextToChar
{
    class TextToChar
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string inputText = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            foreach (var ch in inputText)
            {
                int unicode = Convert.ToInt16(ch);
                string uniStr = unicode.ToString("X");
                int zeros = 4 - uniStr.ToString().Length;

                output.AppendFormat("\\u{0}{1:X}", new string('0', zeros), uniStr);
            }
            Console.WriteLine(output.ToString());

        }
    }
}
