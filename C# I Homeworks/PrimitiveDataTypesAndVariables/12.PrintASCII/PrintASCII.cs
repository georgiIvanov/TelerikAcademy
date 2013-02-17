using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.PrintASCII
{
    class PrintASCII
    {
        static void Main(string[] args)
        {
            char a = '\u0000';
            for (int i = 0; i < 255; i++)
            {
                Console.WriteLine(a);
                a++;
            }
        }
    }
}
