using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.RandomNumbers
{
    class RandomNumbers
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rng.Next(100,201));
            }


        }
    }
}
