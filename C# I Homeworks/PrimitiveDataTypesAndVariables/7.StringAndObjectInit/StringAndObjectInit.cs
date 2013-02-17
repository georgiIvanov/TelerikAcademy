using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.StringAndObjectInit
{
    class StringAndObjectInit
    {
        static void Main(string[] args)
        {
            string hello = "Hello ",
                world = "World";
            object concatenated;
            concatenated = hello + world;

            string third = (string)concatenated;
            Console.WriteLine(third);
        }
    }
}
