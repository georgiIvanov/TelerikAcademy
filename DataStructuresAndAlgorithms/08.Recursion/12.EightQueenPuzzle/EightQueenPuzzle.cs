using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.EightQueenPuzzle
{
    public class EightQueenPuzzle
    {
        public static void Main(String[] args)
        {
            int queensCount = 8;
            int configurationsCount = 0;
            int[] position = new int[queensCount];
            Solve(0, queensCount, position, ref configurationsCount);
        }

        static void Solve(int currentQueen, int queensCount, int[] positions, ref int configurationsCount)
        {
            if (currentQueen == queensCount)
            {
                PrintArr(positions, ref configurationsCount);
            }
            else
            {
                for (int pos = 0; pos < queensCount; pos++)
                {
                    if (isSafe(currentQueen, pos, positions))
                    {
                        positions[currentQueen] = pos;
                        Solve(currentQueen + 1, queensCount, positions, ref configurationsCount);
                    }
                }
            }
        }

        static bool isSafe(int currentQueens, int pos, int[] positions)
        {
            for (int i = 1; i <= currentQueens; i++)
            {
                int other = positions[currentQueens - i];
                if (other == pos || other == pos - i || other == pos + i)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintArr(int[] arr, ref int configurationsCount)
        {

            char[,] field = new char[arr.Length, arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                field[arr[i], i] = 'Q';
            }

            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            Console.WriteLine("Configuration: {0}", ++configurationsCount);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j] == 'Q')
                    {
                        Console.Write("{0, 2}", "Q");
                    }
                    else
                    {
                        Console.Write("{0, 2}", ".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }


}
