using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19.NPermutations
{
    class Program
    {
        

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int[] numbers = new int[N];
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }
            StringBuilder sb = new StringBuilder();
            Queue<HashSet<int>> subsetsQueue = new Queue<HashSet<int>>();
            HashSet<int> emptySet = new HashSet<int>();
            subsetsQueue.Enqueue(emptySet);
            while (subsetsQueue.Count > 0)
            {
                HashSet<int> subset = subsetsQueue.Dequeue();


                if (subset.Count == N)
                {
                    foreach (int word in subset)
                    {
                        sb.AppendFormat("{0} ", word);
                    }
                    sb.AppendLine();

                    
                }

                foreach (int element in numbers)
                {
                    if (!subset.Contains(element))
                    {
                        HashSet<int> newSubset = new HashSet<int>();
                        newSubset.UnionWith(subset);
                        newSubset.Add(element);
                        subsetsQueue.Enqueue(newSubset);
                    }
                }
            }

            Console.Write(sb.ToString());
        }
    }
}