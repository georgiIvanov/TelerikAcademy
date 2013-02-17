using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BitExchange
{
    static void Main(string[] args)
    {
        uint number;
        number = uint.Parse(Console.ReadLine());

        for (int i = 3; i < 6; i++)
		{
            if ((number & (1 << i)) > 0 && ((number & (1 << i+21)) == 0))
            {
                number &= ~(1u << i);
                number |= 1u << (i + 21);
            }
            else if ((number & (1 << i)) == 0 && ((number & (1 << i + 21)) > 0))
            {
                number &= ~(1u << (i + 21));
                number |= 1u << i;
            } 
		}
        Console.WriteLine(number);
    }
}
