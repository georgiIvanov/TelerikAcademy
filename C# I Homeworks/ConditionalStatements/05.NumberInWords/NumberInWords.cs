using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.NumberInWords
{
    class NumberInWords
    {
        static void Main(string[] args)
        {
            //int a = int.Parse(Console.ReadLine());
            int a;
            if (int.TryParse(Console.ReadLine(), out a))
            {

                switch (a)
                {
                    case 1: Console.WriteLine("One"); break;
                    case 2: Console.WriteLine("Two"); break;
                    case 3: Console.WriteLine("Three"); break;
                    case 4: Console.WriteLine("Four"); break;
                    case 5: Console.WriteLine("Five"); break;
                    case 6: Console.WriteLine("Six"); break;
                    case 7: Console.WriteLine("Seven"); break;
                    case 8: Console.WriteLine("Eight"); break;
                    case 9: Console.WriteLine("Nine"); break;
                    case 0: Console.WriteLine("Zero"); break;

                    default: Console.WriteLine("Wrong number"); break;
                }
            }
            else
            {
                Console.WriteLine("Wrong number");
            }


        }
    }
}
