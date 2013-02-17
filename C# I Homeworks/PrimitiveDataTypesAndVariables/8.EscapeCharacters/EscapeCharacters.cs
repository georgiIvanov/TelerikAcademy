using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.EscapeCharacters
{
    class EscapeCharacters
    {
        static void Main(string[] args)
        {
            string first = "The \"use\" of quotations causes difficulties.";
            string second = "The " + "use " + "of quotations causes difficulties.";

            Console.WriteLine(first);
            Console.WriteLine(second);

        }
    }
}
