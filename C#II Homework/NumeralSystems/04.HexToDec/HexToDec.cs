using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.DecToHex
{
    class HexToDec
    {
        static void Main(string[] args)
        {
            Console.Write("Enter hex number, without 0x: ");
            string num = Console.ReadLine().ToUpper();
            int exp = num.Length - 1;
            double decNum = 0, bit = 0;

            foreach (var item in num)
            {
                if (double.TryParse(item.ToString(), out bit))
                {
                    decNum += bit * Math.Pow(16, exp);
                }
                else
                {
                    switch (item)
                    {
                        case 'A': decNum += 10 * Math.Pow(16, exp); break;
                        case 'B': decNum += 11 * Math.Pow(16, exp); break;
                        case 'C': decNum += 12 * Math.Pow(16, exp); break;
                        case 'D': decNum += 13 * Math.Pow(16, exp); break;
                        case 'E': decNum += 14 * Math.Pow(16, exp); break;
                        case 'F': decNum += 15 * Math.Pow(16, exp); break;
                    }
                }

                exp--;
            }

            Console.WriteLine(decNum);


        }
    }
}
