using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.CheckBitAtPosition
{
    class CheckBitAtPosition
    {
        static void Main(string[] args)
        {
            Console.Write("Write number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Write position: ");
            int pos = int.Parse(Console.ReadLine());

            if ((number & (1 << pos)) > 0)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
