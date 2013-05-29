using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.CreateDynamicQueue
{
    class CreateDynamicQueue
    {
        static void Main(string[] args)
        {
            Queue<char> queue = new Queue<char>();

            for (int i = 65; i < 80; i++)
            {
                queue.Push((char)i);
            }

            Console.WriteLine(queue.Peek());
            Console.WriteLine();

            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue.Pop());
            }

            Console.WriteLine();
            queue.Push('A');
            Console.WriteLine(queue.Pop());
            // throws exception when queue is empty
            // Console.WriteLine(queue.Pop());

        }
    }
}
