using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ColoredRabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> rabbits = new Dictionary<int, int>(1000000);
            int numberOfRabbits = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int rabbit = int.Parse(Console.ReadLine());

                if (rabbits.ContainsKey(rabbit))
                {
                    int val = rabbits[rabbit];
                    if (val > rabbit)
                    {
                        numberOfRabbits += rabbit + 1;
                        rabbits.Remove(rabbit);
                    }
                    else
                    {
                        rabbits[rabbit] += 1;
                        if (val == rabbit)
                        {
                            rabbits.Remove(rabbit);
                        }
                    }
                }
                else
                {
                    rabbits.Add(rabbit, 1);
                    numberOfRabbits += rabbit + 1;
                }
            }

            Console.WriteLine(numberOfRabbits);
        }


        //Other solution
        //static void Main()
        //{
        //    int count = int.Parse(Console.ReadLine());
        //    int[] replies = new int[count];

        //    for (int i = 0; i < count; i++)
        //    {
        //        replies[i] = int.Parse(Console.ReadLine());
        //    }

        //    int answer = GetMinimum(replies);
        //    Console.WriteLine(answer);
        //}

        //static int GetMinimum(int[] replies)
        //{
        //    int[] cache = new int[1000002];

        //    for (int i = 0; i < replies.Length; i++)
        //    {
        //        cache[replies[i] + 1]++;
        //    }

        //    int minCount = 0;
        //    for (int i = 0; i < cache.Length; i++)
        //    {
        //        if (cache[i] == 0) 
        //        {
        //            continue;
        //        }
        //        if (cache[i] <= i)
        //        {
        //            minCount += i;
        //        }
        //        else
        //        {
        //            minCount += (int)Math.Ceiling((double)cache[i] / i) * i;
        //        }
        //    }

        //    return minCount;
        //}
    }
}
