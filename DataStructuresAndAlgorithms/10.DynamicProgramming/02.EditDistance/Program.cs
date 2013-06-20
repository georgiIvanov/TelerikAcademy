using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EditDistance
{
    class Program
    {
        const int MAX = 10;
        const decimal costDelete = 0.9m;
        const decimal costInsert = 0.8m;

        static decimal[,] F = new decimal[MAX + 1, MAX + 1];
        static int n1;
        static int n2;
        static string s1 = "evelo2per";
        static string s2 = "enveloped";

        static decimal EditDistance()
        {
            int i, j;
            for (i = 0; i <= n1; i++)
            {
                F[i, 0] = i * costDelete;
            }
            for (j = 0; j <= n2; j++)
            {
                F[0, j] = j * costInsert;
            }

            for (i = 1; i <= n1; i++)
            {
                for (j = 1; j <= n2; j++)
                {
                    decimal replace = F[i - 1, j - 1] + costReplace(i, j);
                    decimal insert = F[i, j - 1] + costInsert;
                    decimal delete = F[i - 1, j] + costDelete;
                    F[i, j] = Min(replace, insert, delete);
                }
            }

            return F[n1, n2];
        }

        static int costReplace(int i, int j)
        {
            return s1[i] == s2[j] ? 0 : 1;
        }

        static decimal Min(decimal replace, decimal insert, decimal delete)
        {
            decimal smaller = replace < insert ? replace : insert;
            decimal smallest = smaller < delete ? smaller : delete;

            return smallest;
        }

        static void PrintEditOperations(int i, int j)
        {
            if (j == 0)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.Write("Delete({0}) ", j);
                }
            }
            else if (i == 0)
            {
                for (i = 1; i <= j; i++)
                {
                    Console.Write("Insert({0}, {1}) ", i, s2[i]);
                }
            }
            else if (i > 0 && j > 0)
            {
                if (F[i, j] == F[i - 1, j - 1] + costReplace(i, j))
                {
                    PrintEditOperations(i - 1, j - 1);
                    if (costReplace(i, j) > 0)
                    {
                        Console.Write("Replace({0},{1}) ", i, s2[j]);
                    }
                }
                else if (F[i, j] == F[i, j - 1] + costInsert)
                {
                    PrintEditOperations(i, j - 1);
                    Console.Write("Insert({0},{1}) ", i, s2[j]);
                }
                else if (F[i, j] == F[i - 1, j] + costDelete)
                {
                    PrintEditOperations(i - 1, j);
                    Console.Write("Delete({0}) ", i);
                }
            }
        }

        static void Main(string[] args)
        {
            n1 = s1.Length - 1;
            n2 = s2.Length - 1;
            Console.WriteLine("Minimal distance between two strings: {0}", EditDistance());
            PrintEditOperations(n1, n2);

            Console.WriteLine("\n");
        }

        
    }
}
