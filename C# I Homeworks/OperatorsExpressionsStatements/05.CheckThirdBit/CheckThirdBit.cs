using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.CheckThirdBit
{
    class CheckThirdBit
    {
        static void Main(string[] args)
        {
            int number = new int();
            int.TryParse(Console.ReadLine(), out number);

            if ((number & (1 << 3)) == 0)
            {
                Console.WriteLine("Third bit is 0");
            }
            else
            {
                Console.WriteLine("Third bit is 1");
            }
        }
    }
}
