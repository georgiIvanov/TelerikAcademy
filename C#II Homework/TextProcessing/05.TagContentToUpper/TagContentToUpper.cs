using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace _05.TagContentToUpper
{
    class TagContentToUpper
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int index = 0, endOfNode = 0;

            string upcase = "<upcase>";
            int substrCount = 0;

            while (index != -1 + upcase.Length)
            {
                index = input.IndexOf(upcase, index) + upcase.Length;
                substrCount++;
            }
            Console.WriteLine();

            index = 0;
            for(int i = 0; i < substrCount-1; i++)
            {
                index = input.IndexOf("<upcase>", index) + 8;
                endOfNode = input.IndexOf("</upcase>", index);
                string substr = input.Substring(index, endOfNode - index);
                input = input.Replace(substr, substr.ToUpper());
            }
            Console.WriteLine(input);


        }
    }
}
