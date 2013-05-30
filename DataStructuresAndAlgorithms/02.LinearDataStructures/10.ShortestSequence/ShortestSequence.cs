using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _10.ShortestSequence
{
    class ShortestSequence
    {
        static List<int> DetermineShortestSequence(Queue<List<int>> queueList, int target)
        {
            List<int> result;

            while (true)
            {
                List<int> currentList = queueList.Dequeue();
                int currentLastElement = currentList[currentList.Count - 1];

                int plusOneValue = currentLastElement + 1;
                List<int> plusOneList = new List<int>(currentList);
                plusOneList.Add(plusOneValue);
                if (plusOneValue < target)
                {
                    queueList.Enqueue(plusOneList);
                }
                else
                {
                    result = plusOneList;
                    break;
                }

                int plusTwoValue = currentLastElement + 2;
                List<int> plusTwoList = new List<int>(currentList);
                plusTwoList.Add(plusTwoValue);
                if (plusTwoValue < target)
                {
                    queueList.Enqueue(plusTwoList);
                }
                else
                {
                    result = plusTwoList;
                    break;
                }

                int multiplyByTwoValue = 2 * currentLastElement;
                List<int> multiplyByTwoList = new List<int>(currentList);
                multiplyByTwoList.Add(multiplyByTwoValue);
                if (multiplyByTwoValue < target)
                {
                    queueList.Enqueue(multiplyByTwoList);
                }
                else if (multiplyByTwoValue == target)
                {
                    result = multiplyByTwoList;
                    break;
                }
            }

            return result;
        }

        static void Main()
        {
            int n = 5;
            int m = 16;

            Queue<List<int>> queueList = new Queue<List<int>>();
            queueList.Enqueue(new List<int>(new int[] {n}));

            List<int> result = DetermineShortestSequence(queueList, m);

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