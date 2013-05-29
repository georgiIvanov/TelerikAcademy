using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CreateStack
{
    class CreateStack
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 1; i < 11; i++)
			{
                stack.Push(i);
			}

            Console.WriteLine(stack.Peek());
            Console.WriteLine();

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            stack.Push(300);
            Console.WriteLine();

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}
