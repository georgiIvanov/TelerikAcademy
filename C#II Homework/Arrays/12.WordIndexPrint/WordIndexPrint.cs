using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.WordIndexPrint
{
    class WordIndexPrint
    {
        static void Main(string[] args)
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
                                'U','V','W','X','Y','Z',};
            string word = Console.ReadLine().ToUpper();

            
            foreach (var item in word)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (alphabet[i] == item)
                    {
                        Console.Write("{0} ", i);
                    }
                }

            }

        }
    }
}
