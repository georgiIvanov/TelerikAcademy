using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            while (num != 0)
            {
                if ((num & 1) == 0)
                {
                    sb.Append("0");
                }
                else
                {
                    sb.Append("1");
                }
                num >>= 1;
            }

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                Console.Write(sb[i]);
            }
        }
    }
}
