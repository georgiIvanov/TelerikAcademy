using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorsExpressionsStatements
{
    class OddOrEven
    {
        static void Main(string[] args)
        {
            int number = new int();
            int.TryParse(Console.ReadLine(), out number);

            Console.WriteLine((number & 1) == 0 ? "Even" : "Odd");
        }
    }
}
