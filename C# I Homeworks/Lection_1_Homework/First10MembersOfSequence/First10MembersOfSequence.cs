using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace First10MembersOfSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int positiveS = 2, negativeS = -3;
            for (int i = 0; i < 10; i++)
            {
                Console.Write(positiveS + " " + negativeS + "  ");
                positiveS += 2;
                negativeS -= 2;
            }
            Console.WriteLine();
        }
    }
}
