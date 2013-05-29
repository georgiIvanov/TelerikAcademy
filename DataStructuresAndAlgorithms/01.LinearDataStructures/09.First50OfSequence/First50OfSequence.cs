using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.First50OfSequence
{
    class First50OfSequence
    {
        static void Main(string[] args)
        {
            Queue<int> sequence = new Queue<int>();
            int n = 2;
            sequence.Enqueue(n);
            for (int i = 0; i < 50/3 - 1; i++)
            {
                int sValue = sequence.ElementAt(i);
                sequence.Enqueue(sValue + 1);
                sequence.Enqueue(2 * sValue + 1);
                sequence.Enqueue(sValue + 2);
            }

            foreach (var item in sequence)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
