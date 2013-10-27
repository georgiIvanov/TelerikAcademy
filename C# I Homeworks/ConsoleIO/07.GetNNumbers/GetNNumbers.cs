using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.GetNNumbers
{
    class GetNNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = n; i > 0; i--)
            {
                sum += int.Parse(Console.ReadLine());
            }


            Console.WriteLine(sum);
        }
    }
}
