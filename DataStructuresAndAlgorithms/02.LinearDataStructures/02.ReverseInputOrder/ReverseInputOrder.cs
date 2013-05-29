using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ReverseInputOrder
{
    class ReverseInputOrder
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            GetNumbers(stack);

            PrintNumbers(stack);
        }

        private static void GetNumbers(Stack<int> stack)
        {
            string input = null;
            while (input != "")
            {
                int number;
                input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    stack.Push(number);
                }
            }
        }

        private static void PrintNumbers(Stack<int> stack)
        {
            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }
        }
    }
}
