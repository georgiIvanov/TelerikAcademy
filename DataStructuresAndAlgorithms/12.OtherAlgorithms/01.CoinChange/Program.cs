using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startCoins = 33;
            int[] change = new int[3];
            //indices 0, 1, 2 -> 5st, 2st, 1st

            GetChange(ref startCoins, change);


            Console.WriteLine("{0} coins x5", change[0]);
            Console.WriteLine("{0} coins x2", change[1]);
            Console.WriteLine("{0} coins x1", change[2]);
        }

        static void GetChange(ref int coins, int[] change)
        {
            if (coins >= 5)
            {
                change[0] += 1;
                coins -= 5;
            }
            else if (coins >= 2)
            {
                change[1] += 1;
                coins -= 2;
            }
            else if (coins >= 1)
            {
                change[2] += 1;
                coins -= 1;
            }

            if (coins > 0)
            {
                GetChange(ref coins, change);
            }
            else
            {
                return;
            }
        }
    }
}
