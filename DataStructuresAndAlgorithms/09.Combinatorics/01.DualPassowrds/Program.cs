using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DualPassowrds
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            int unknownNumbers = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == '*')
                {
                    unknownNumbers++;
                }
            }

            ulong result = 1;
            for (int i = 1; i <= unknownNumbers; i++)
			{
                result <<= 1;
			}

            Console.WriteLine(result);
        }
    }
}
