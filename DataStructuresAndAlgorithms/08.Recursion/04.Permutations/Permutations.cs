using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Permutations
{
    class Permutations
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[] used = new int[n];
            int[] mp = new int[n];

            Permute(0, n, mp, used);
        }

        static void Permute(int i, int n, int[] mp, int[] used)
        {
            if (i >= n)
            {
                Print(n, mp);
                return;
            }

            for (int k = 0; k < n; k++)
            {
                if (used[k] == 0)
                {
                    used[k] = 1;
                    mp[i] = k;
                    Permute(i + 1, n, mp, used);
                    used[k] = 0;
                }
            }

        }

        static void Print(int n, int[] mp)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", mp[i] + 1);
            }
            Console.WriteLine();
        }
    }
}
