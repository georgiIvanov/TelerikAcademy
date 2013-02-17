using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.FixedStrLength
{
    class FixedStrLength
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 20; i++)
            {
                if (i < input.Length)
                {
                    output.Append(input[i]);
                }
                else
                {
                    output.Append("*");
                }
            }
            Console.WriteLine(output.ToString());

        }
    }
}
