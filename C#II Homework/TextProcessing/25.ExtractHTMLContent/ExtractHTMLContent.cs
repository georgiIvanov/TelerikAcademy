using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace _25.ExtractHTMLContent
{
    class ExtractHTMLContent
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to HTML file: ");
            string path = Console.ReadLine();

            //string HTML = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">TelerikAcademy</a>aims to provide free real-world practicaltraining for young people who want to turn into skillful .NET software engineers.</p></body></html>";
            //For fast check comment next 6 lines and uncomment the above
            StreamReader sr = new StreamReader(path);
            string HTML;
            using (sr)
            {
                HTML = sr.ReadToEnd();
            }

            
            
            foreach (Match text in Regex.Matches(HTML, ">(.*?)<"))
                if (!String.IsNullOrWhiteSpace(text.Groups[1].Value))
                    Console.WriteLine(text.Groups[1]);


        }
    }
}
