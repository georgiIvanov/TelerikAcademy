using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FactDivision
{
    class FactDivision
    {
        static void Main(string[] args)
        {
            int n = 0;
            int k = 0;
            do
            {
                n = int.Parse(Console.ReadLine());
                k = int.Parse(Console.ReadLine());
            } while (1 > n || k < n);

            int diff = k - n;

            if (diff < n)
            {
                int factRemains = 1;
                for (int i = diff + 1; i <= n; i++)
                {
                    factRemains *= i;
                }

                for (int i = 1; i <= k; i++)
                {
                    factRemains *= i;
                }
                Console.WriteLine(factRemains);
            }
            else if (diff == n)
            {
                int factRemains = 1;
                for (int i = 1; i <= k; i++)
                {
                    factRemains *= i;
                }
                Console.WriteLine(factRemains);
            }
            else if (diff > n)
            {
                int factRemainsD = 1, //fact in denominator
                    factNumerator = 1; //fact in nom

                for (int i = n + 1; i <= diff; i++)
                {
                    factRemainsD *= i;
                }

                for (int i = 1; i <= k; i++)
                {
                    factNumerator *= i;
                }

                factNumerator /= factRemainsD;
                Console.WriteLine(factNumerator);


            }


            
        }
    }
}
