using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {

            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(12);
            priorityQueue.Enqueue(13);
            priorityQueue.Enqueue(14);
            priorityQueue.Enqueue(15);

            Console.WriteLine("Peek at biggest element: {0} ", priorityQueue.Peek);
            priorityQueue.Dequeue();

            Console.WriteLine("Peek after dequeue: {0}", priorityQueue.Peek);

            priorityQueue.Enqueue(15);
            priorityQueue.Enqueue(20);
            Console.WriteLine("Biggest element after enqueue: {0} ", priorityQueue.Peek);
        }
    }
}
