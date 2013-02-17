using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.MatrixOutput
{
    class MatrixOutput
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j < i + n; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            //int n = int.Parse(Console.ReadLine());

            //int numbers = 1;
            //int[,] matrix = new int[n, n];

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        matrix[i, j] = numbers;
            //        numbers++;
            //    }
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        Console.Write("{0}\t",matrix[i, j]);
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
