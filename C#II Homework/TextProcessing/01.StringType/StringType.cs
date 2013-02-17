using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.StringType
{
    class StringType
    {
        static void Main(string[] args)
        {
            string subject = "string - ";
            
            Console.WriteLine("{0}Primitive type in .NET based languages, derives from System.Object", subject);
            string text = "Which makes it a reference type, but it is also immutable,";
            Console.WriteLine(text.PadLeft(text.Length + subject.Length));
            text = "because of that it behaves as a value type in sertain situations.";
            Console.WriteLine(text.PadLeft(text.Length + subject.Length));
            Console.WriteLine("\nImportant methods: \n");
            Console.WriteLine("IndexOf() - finds the first index of a match with the argument");
            Console.WriteLine("Substring() - returns a substring of a string");
            Console.WriteLine("Replace() - replaces a given substring with another and returns new stirng");
            Console.WriteLine("Split() - splits a string by given element");


            //Console.WriteLine("Which makes it a reference type, but it is also immutable,".PadLeft(13));
            //Console.WriteLine("which makes itbehave like a value type".PadLeft(13));
            
        }
    }
}
