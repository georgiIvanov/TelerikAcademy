using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_ShortestSequOfOperators
{
    class MinOperators
    {
        static List<int> FindMinOperations(Queue<List<int>> queueList, int M)
        {
            while (true)
            {
                List<int> currentList = queueList.Dequeue();
                int currentLastElement = currentList[currentList.Count - 1];

                int firstNextValue = currentLastElement + 1;
                List<int> firstNextList = new List<int>(currentList);
                firstNextList.Add(firstNextValue);
                if (firstNextValue < M)
                {
                    queueList.Enqueue(firstNextList);
                }
                else if (firstNextValue == M)
                {
                    queueList.Enqueue(firstNextList);
                    return firstNextList;
                }

                int secondNextValue = currentLastElement + 2;
                List<int> secondNextList = new List<int>(currentList);
                secondNextList.Add(secondNextValue);
                if (secondNextValue < M)
                {
                    queueList.Enqueue(secondNextList);
                }
                else if (secondNextValue == M)
                {
                    queueList.Enqueue(secondNextList);
                    return secondNextList;
                }

                int thirdNextValue = currentLastElement * 2;
                List<int> thirdNextList = new List<int>(currentList);
                thirdNextList.Add(thirdNextValue);
                if (thirdNextValue < M)
                {
                    queueList.Enqueue(thirdNextList);
                }
                else if (thirdNextValue == M)
                {
                    queueList.Enqueue(thirdNextList);
                    return thirdNextList;
                }
            }

        }
        static void aa(string[] args)
        {
            int n = 3;
            int m = 23;

            List<int> firstList = new List<int>();
            firstList.Add(n);

            Queue<List<int>> solutions = new Queue<List<int>>();
            solutions.Enqueue(firstList);


            List<int> result = FindMinOperations(solutions, m);

            Console.Write("Result: ");

            for (int i = 0; i < result.Count; i++)
            {
                if (i < result.Count - 1)
                {
                    Console.Write("{0}->", result[i]);
                }
                else
                {
                    Console.WriteLine("{0}", result[i]);
                }
            }
        }
    }
}