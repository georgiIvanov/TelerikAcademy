using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _15.TagReplace
{
    class TagReplace
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string inputText = Console.ReadLine();

            int aIndex = 0, startIndex = 0, endIndex = 0;
            string url;
            while (aIndex < inputText.Length)
            {
                aIndex = inputText.IndexOf("<a ", aIndex);
                startIndex = inputText.IndexOf('"', aIndex + 3);
                endIndex = inputText.IndexOf('"', startIndex + 1);
                url = inputText.Substring(startIndex + 1, endIndex - startIndex - 1);
                

                endIndex = inputText.IndexOf(">", endIndex) + 1;
                inputText = inputText.Replace(inputText.Substring(aIndex, endIndex - aIndex),
                    "[URL=" + url + "]");
                aIndex += endIndex;
            }
            inputText = inputText.Replace("</a>", "[/URL]");
            Console.WriteLine(inputText);
        }
    }
}
