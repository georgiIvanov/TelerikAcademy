using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            string binNum = Console.ReadLine();
            int exponent = binNum.Length - 1;
            StringBuilder sb = new StringBuilder();

            int bit; 
            double decNum = 0;
            foreach (var item in binNum)
            {
                bit = Convert.ToInt32(item);
                if ((bit & 1) == 1)
                {
                    decNum += Math.Pow(2, exponent);
                }
                exponent--;
            }
            Console.WriteLine(decNum);
        }
    }
}
