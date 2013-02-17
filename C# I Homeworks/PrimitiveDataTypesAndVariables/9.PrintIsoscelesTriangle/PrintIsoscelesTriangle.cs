using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9.PrintIsoscelesTriangle
{
    class PrintIsoscelesTriangle
    {
        static void Main(string[] args)
        {
            char copy = '\u00A9';
            int row = 3, chars = 1, col = 5;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < (col - chars)/2; j++)
                {
                    Console.Write("  ");
                }
                for (int j = 0; j < chars; j++)
                {
                    Console.Write(copy + " ");
                }
                chars += 2;
                Console.WriteLine();
            }
        }
    }
}
