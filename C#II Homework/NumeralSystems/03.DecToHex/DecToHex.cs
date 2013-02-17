using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.DecToHex
{
    class DecToHex
    {
        static void Main(string[] args)
        {
            int decNum = int.Parse(Console.ReadLine());
            int remainder = 0;
            StringBuilder sb = new StringBuilder();

            while (decNum != 0)
            {
                remainder = decNum % 16;
                if (remainder <= 9)
                {
                    sb.Append(remainder);
                }
                else
                {
                    switch (remainder)
                    {
                        case 10: sb.Append("A"); break;
                        case 11: sb.Append("B"); break;
                        case 12: sb.Append("C"); break;
                        case 13: sb.Append("D"); break;
                        case 14: sb.Append("E"); break;
                        case 15: sb.Append("F"); break;
                    }
                }
                decNum >>= 4;
            }

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                Console.Write(sb[i]);
            }
            Console.WriteLine();
        }
    }
}
