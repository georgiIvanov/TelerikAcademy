using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.ModifyGivenBitPosition
{
    class ModifyGivenBitPosition
    {
        static void Main(string[] args)
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Position: ");
            int pos = int.Parse(Console.ReadLine());
            Console.Write("Bit (0 or 1): ");
            int bit = int.Parse(Console.ReadLine());

            if (bit == 0)
            {
                number &= ~(1 << pos);
            }
            else if (bit == 1)
            {
                number |= bit << pos;
            }
            

            Console.WriteLine(number);


        }
    }
}
