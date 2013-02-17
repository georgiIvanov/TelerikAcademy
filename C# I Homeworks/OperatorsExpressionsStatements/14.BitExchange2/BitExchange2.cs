using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

class BitExchange
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        Console.Write("Enter number: ");
        uint number;
        number = uint.Parse(Console.ReadLine());
        Console.Write("Enter length of sequences: ");
        uint k = uint.Parse(Console.ReadLine());
        Console.Write("Enter first bit of first sequence: ");
        uint p = uint.Parse(Console.ReadLine());
        Console.Write("Enter first bit of second sequence: ");
        uint q = uint.Parse(Console.ReadLine());
        sw.Start();
        int diff = Convert.ToInt32(q - p);

        for (int i = Convert.ToInt32(p); i < k; i++)
        {
            if ((number & (1 << i)) > 0 && ((number & (1 << i + diff)) == 0))
            {
                number &= ~(1u << i);
                number |= 1u << (i + diff);
            }
            else if ((number & (1 << i)) == 0 && ((number & (1 << i + diff)) > 0))
            {
                number &= ~(1u << (i + diff));
                number |= 1u << i;
            }
        }

        Console.WriteLine(number);
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }

}
