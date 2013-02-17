using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _05.BiggestSubMatrix
{
    class BiggestSubMatrix
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../matrix.txt");
            int mSize, row = 0, col = 0;
            

            mSize = int.Parse(sr.ReadLine());
            int[,] matrix = new int[mSize,mSize];

            for (int i = 0; i < mSize; i++)
            {
                col = 0;
                string[] numbers = sr.ReadLine().Split();
                foreach (var item in numbers)
                {
                    matrix[row, col] = int.Parse(item);
                    col++;
                }
                row++;
            }
            sr.Close();

            int biggestSum = int.MinValue, currentSum = 0;
            for (int i = 0; i <= mSize - 2; i++)
            {
                for (int j = 0; j <= mSize - 2; j++)
                {
                    currentSum = 0;
                    for (int r = i; r < i+2; r++)
                    {
                        for (int c = j; c < j+2; c++)
                        {
                            currentSum += matrix[r, c];
                        }
                    }
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                    }
                }
            }

            StreamWriter sw = new StreamWriter("../../../05.Result.txt");

            using (sw)
            {
                sw.Write(biggestSum);
            }
            
        }
    }
}
