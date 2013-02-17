using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.LargestArea
{
    class LargestArea
    {
        static void Main(string[] args)
        {
            int[,] matrix = { { 1, 3, 2, 2, 2, 4 }, 
                              { 3, 3, 3, 2, 4, 4 }, 
                              { 4, 3, 1, 2, 3, 3 }, 
                              { 4, 3, 1, 3, 3, 1 }, 
                              { 4, 3, 3, 3, 1, 1 }
                            };
            int m = matrix.GetLength(0) - 1;
            int n = matrix.GetLength(1) - 1;
            int[,] map = new int[m + 1,n + 1];


            int count = int.MinValue;
            int currentCount = 0;
            int areaValue = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentCount = 1;
                    if (map[i, j] == 0)
                    {
                        map[i, j] = 1;
                        Traverse(matrix, map, matrix[i, j], i, j, n, m, ref currentCount);

                    }
                    if (currentCount > count)
                    {
                        count = currentCount;
                        areaValue = matrix[i, j];
                    }
                }
            }

            Console.WriteLine("Area value: {0}", areaValue);
            Console.WriteLine("Size: {0}", count);

        }

        static void Traverse(int[,] matrix, int[,] map, int value, int y, int x, int nSize, int mSize, ref int currentCount)
        {
            for (int i = y- 1; i <= y+ 1; i++)
            {
                if (i < 0 || i > mSize) continue;
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (j < 0 || j > nSize) continue;
                    if (matrix[i, j] == value && map[i, j] == 0)
                    {
                        currentCount++;
                        map[i, j] = 1;
                        Traverse(matrix, map, value, i, j, nSize, mSize, ref currentCount);
                    }
                }
            }

        }
    }
}
