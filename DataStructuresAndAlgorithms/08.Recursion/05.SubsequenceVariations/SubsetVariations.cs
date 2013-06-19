using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SubsequenceVariations
{
    class SubsetVariations
    {
        static void Main(string[] args)
        {
            int k = 2;
            string[] set = new string[] { "hi", "a", "b" };
            int[] variationIndexes = new int[set.Length];

            Variate(0, k, set.Length, set, variationIndexes);
        }

        static void Variate(int i, int k, int n, string[] set, int[] varIndexes)
        {
            if (i >= k)
            {
                Print(k, set, varIndexes);
                return;
            }

            for (int j = 0; j < n; j++)
            {
                varIndexes[i] = j;
                Variate(i + 1, k, n, set, varIndexes);
            }

        }

        static void Print(int n, string[] set, int[] varIndexes)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", set[varIndexes[i]]);
            }
            Console.WriteLine();
        }
    }
}
