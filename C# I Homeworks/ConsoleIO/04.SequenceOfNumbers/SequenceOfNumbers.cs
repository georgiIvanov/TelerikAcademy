using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.SequenceOfNumbers
{
    class SequenceOfNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int p = 0;

            for (int i = a; i <= b; i++)
            {
                if (i % 5 == 0)
                {
                    p++;
                }
            }
            Console.WriteLine(p);
        }
    }
}
