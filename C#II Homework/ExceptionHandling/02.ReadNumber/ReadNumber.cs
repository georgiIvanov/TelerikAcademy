using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.ReadNumber
{
    class ReadNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter start: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter end: ");
            int end = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter 10 numbers between {0} and {1}: ",start, end);

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadNum(start, end);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        static void ReadNum(int start, int end)
        {
            int num = int.Parse(Console.ReadLine());

            if (num > start && num < end || num < start && num > end)
            {
                Console.WriteLine("You entered: {0}",num);
            }
            else
            {
                throw new ArgumentException("Number is not between start and end");
            }
        }
    }
}
