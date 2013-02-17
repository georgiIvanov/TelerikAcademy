using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ShortToBin
{
    static void Main(string[] args)
    {
        short shortNum = short.Parse(Console.ReadLine());
            
        Console.WriteLine(Convert.ToString(shortNum, 2));

    }
}
