using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _18.EmailExtract
{
    class EmailExtract
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text with emails in it: ");
            string inputText = Console.ReadLine();

            MatchCollection matches = Regex.Matches(inputText, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*");

            if (matches.Count > 0)
            {
                foreach (var item in matches)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No emails found");
            }

        }
    }
}
