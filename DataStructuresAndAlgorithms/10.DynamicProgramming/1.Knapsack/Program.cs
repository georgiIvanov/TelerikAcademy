using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Knapsack
{
    class Program
    {
        const uint NOT_CALCULATED = uint.MaxValue;

        static uint[,] set = new uint[1000, 30];
        static uint[] Fn = new uint[1000];

        static Item[] items = new Item[]{ 
            new Item{Name = "beer", Weight = 3, Cost = 2},
            new Item{Name = "vodka", Weight = 8, Cost = 12},
            new Item{Name = "cheese", Weight = 4, Cost = 5},
            new Item{Name = "nusts", Weight = 1, Cost = 4},
            new Item{Name = "ham", Weight = 2, Cost = 3},
            new Item{Name = "whiskey", Weight = 8, Cost = 13},
        };
        const uint M = 10;                          
        const uint N = 5;                           

        static void FindItems(uint k)
        {
            uint i = 1, bestI = 0, bestRatio = 0, currentRatio = 0;

            for (; i <= N; i++)
            {
                if (k >= items[i].Weight)
                {
                    if( NOT_CALCULATED == Fn[k - items[i].Weight])
                    {
                        FindItems(k - items[i].Weight);
                    }
                    if (set[k - items[i].Weight, i] == 0)
                    {
                        currentRatio = items[i].Cost + Fn[k - items[i].Weight];
                    }
                    else
                    {
                        currentRatio = 0;
                    }

                    if (currentRatio > bestRatio)
                    {
                        bestI = i;
                        bestRatio = currentRatio;
                    }
                }
            }

            Fn[k] = bestRatio;
            if (bestI > 0)
            {
                uint row = k - items[bestI].Weight;
                for (int j = 0; j <= N; j++)
                {
                    set[k, j] = set[row, j];
                }
                set[k, bestI] = 1;
            }
        }

        static void Calculate()
        {
            uint i = 0, sumM = 0;
            for (i = 0; i <= M; i++)
            {
                Fn[i] = NOT_CALCULATED;
            }

            for (sumM = items[1].Weight, i = 2; i <= N; i++)
            {
                sumM += items[i].Weight;
            }

            if (M >= sumM)
            {
                Console.WriteLine("you can carry all the items");
                return;
            }
            else
            {
                FindItems(M);
                Console.WriteLine("Get items: ");
                for (i = 1; i <= N; i++)
                {
                    if (set[M, i] > 0)
                    {
                        Console.Write("{0}  ", items[i].Name);
                    }
                }

                Console.WriteLine("\nMaximal value: {0}", Fn[M]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Number of elements: {0}", N);
            Console.WriteLine("Bag capacity: {0}", M);
            Calculate();
        }
    }
}
