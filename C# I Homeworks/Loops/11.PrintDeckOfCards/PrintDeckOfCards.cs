using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.PrintDeckOfCards
{
    class PrintDeckOfCards
    {
        static void Main(string[] args)
        {
            string[] suits = { "\u2660", "\u2665", "\u2666", "\u2663" };

            foreach (var item in suits)
            {
                for (int i = 0; i <= 13; i++)
                {
                    switch (i)
                    {
                        case 0: Console.WriteLine("Ace " + item); break;
                        case 1: Console.WriteLine("Two " + item); break;
                        case 2: Console.WriteLine("Three " + item); break;
                        case 3: Console.WriteLine("Four " + item); break;
                        case 4: Console.WriteLine("Five " + item); break;
                        case 6: Console.WriteLine("Six " + item); break;
                        case 7: Console.WriteLine("Seven " + item); break;
                        case 8: Console.WriteLine("Eight " + item); break;
                        case 9: Console.WriteLine("Nine " + item); break;
                        case 10: Console.WriteLine("Ten " + item); break;
                        case 11: Console.WriteLine("Jack " + item); break;
                        case 12: Console.WriteLine("Queen " + item); break;
                        case 13: Console.WriteLine("King " + item); break;
                    }
                }

                Console.WriteLine();
            }


        }
    }
}
