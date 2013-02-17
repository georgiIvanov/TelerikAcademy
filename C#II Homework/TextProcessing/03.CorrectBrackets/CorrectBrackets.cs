using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.CorrectBrackets
{
    class CorrectBrackets
    {
        static void Main(string[] args)
        {
            bool openBrackets = false;
            int brackets = 0;
            string input = Console.ReadLine();

            if (input[0] == ')')
            {
                Console.WriteLine("Brackets are incorrect");
            }
            else
            {
                foreach (var ch in input)
                {
                    if (ch == ')')
                    {
                        openBrackets = false;
                        brackets--;
                    }
                    else if (ch == '(')
                    {
                        openBrackets = true;
                        brackets++;
                    }
                }

                if (brackets == 0 && openBrackets == false)
                {
                    Console.WriteLine("Brackets are correct");
                }
                else
                {
                    Console.WriteLine("Brackets are incorrect");
                }
            }

        }
    }
}
