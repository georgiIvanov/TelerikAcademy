using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RiskWinsRiskLoses
{
    class Program
    {
        static int startPosition;
        static int endPosition;
        static int numberOfForbiddenCombinations;
        static bool[] forbiddenCombinations = new bool[100000];

        static void Main(string[] args)
        {
            int[] powerOf10 = new int[5];
            powerOf10[0] = 1;
            for (int i = 1; i < 5; i++)
            {
                powerOf10[i] = powerOf10[i - 1] * 10;
            }

            startPosition = int.Parse(Console.ReadLine());
            endPosition = int.Parse(Console.ReadLine());

            numberOfForbiddenCombinations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfForbiddenCombinations; i++)
			{
                int forbiddenCombination = int.Parse(Console.ReadLine());
                forbiddenCombinations[forbiddenCombination] = true;
			}

            Queue<Tuple<int, int>> queue = new Queue<Tuple<int,int>>();
            queue.Enqueue(new Tuple<int,int>(startPosition, 0));

            var used = new bool[100000];
            used[startPosition] = true;

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                if(current.Item1 == endPosition)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }

                for (int i = 0; i < 5; i++)
			    {
                    int newEdge;
                    int digit = (current.Item1 / powerOf10[i] % 10);
                    if (digit != 9)
                    {
                        newEdge = current.Item1 + powerOf10[i];
                    }
                    else
                    {
                        newEdge = current.Item1 - 9 * powerOf10[i];
                    }

                    if (!used[newEdge])
                    {
                        if (forbiddenCombinations[newEdge])
                        {
                            continue;
                        }
                        used[newEdge] = true;
                        queue.Enqueue(new Tuple<int, int>(newEdge, current.Item2 + 1));
                    }
			    }

                for (int i = 0; i < 5; i++)
                {
                    int newEdge;
                    int digit = (current.Item1 / powerOf10[i] % 10);
                    if (digit != 0)
                    {
                        newEdge = current.Item1 - powerOf10[i];
                    }
                    else
                    {
                        newEdge = current.Item1 + 9 * powerOf10[i];
                    }

                    if (!used[newEdge])
                    {
                        if (forbiddenCombinations[newEdge])
                        {
                            continue;
                        }

                        used[newEdge] = true;
                        queue.Enqueue(new Tuple<int, int>(newEdge, current.Item2 + 1));
                    }
                }

            }
            Console.WriteLine(-1);
        }
    }
}
