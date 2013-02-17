using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.CheckIfThirdDigitIs7
{
    class CheckIfThirdDigitIs7
    {
        static void Main(string[] args)
        {
            int number = new int();
            int.TryParse(Console.ReadLine(), out number);

            number /= 100;
            int thirdDigit = number % 10;
            if (thirdDigit == 7)
            {
                Console.WriteLine("Third digit is 7");
            }
            else
            {
                Console.WriteLine("Third digit is something elese");
            }
        }
    }
}
