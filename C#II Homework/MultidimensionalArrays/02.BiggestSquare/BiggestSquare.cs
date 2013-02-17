using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.BiggestSquare
{
    class BiggestSquare
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M: ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];
            int biggestY = 0, biggestX = 0, count = int.MinValue;

            Console.WriteLine("Enter numbers for matrix, each on new line: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            //quicktest
            //int[,] matrix = {{1,2,3,4}, {4,5,6,7}, {8,9,10,11} };
            //int n = 3, m = 4;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    GetCount(matrix, i, j, ref biggestY, ref biggestX, ref count, n, m);
                }
            }

            Console.WriteLine("\nBiggest square is: ");
            for (int i = biggestY - 1; i <= biggestY + 1; i++)
            {
                for (int j = biggestX - 1; j <= biggestX + 1; j++)
                {
                    Console.Write("{0}\t", matrix[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Count: {0}", count);

        }

        static void GetCount(int[,] matrix, int y, int x, ref int biggestY, ref int biggestX, ref int count, int n, int m)
        {
            int currentCount = 0;
            if (x + 1 >= m) return;
            if (y + 1 >= n) return;
            for (int i = y - 1; i <= y + 1; i++)
			{
                for (int j = x - 1; j <= x + 1; j++)
			    {
                    currentCount += matrix[i, j];
			    }
			}

            if (currentCount > count)
            {
                count = currentCount;
                biggestX = x;
                biggestY = y;
            }
        }
    }
}
