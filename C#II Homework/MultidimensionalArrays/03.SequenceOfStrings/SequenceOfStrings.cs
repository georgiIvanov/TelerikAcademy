using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.SequenceOfStrings
{
    enum Direction
    {
        NorthWest,        North,        NorthEast,
        West, SouthWest, South, SouthEast, East
    }
    class SequenceOfStrings
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter M: ");
            int m = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, m];
            Direction dir = new Direction();

            Console.WriteLine("Enter strings (each is new line): ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }
            }
            //test matrix
            //int n = 3, m = 4;
            //string[,] matrix = { {"z","b","c","d"}, 
            //                     {"e","z","c","h"}, 
            //                    {"h", "b","z","m"}  
            //                   };

            string seqStr = "";
            int count = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    SearchForEqualStrings(matrix, i, j, n, m, ref count, ref seqStr);
                }
            }

            Console.WriteLine("Sequence: {0}, repeated {1}", seqStr, count);

        }

        static void SearchForEqualStrings(string[,] matrix, int y, int x, int n, int m, ref int count, ref string seqStr)
        {
            Direction dir = new Direction();
            int centerX = x, centerY = y;
            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    if (i < 0 || i >= n) continue;
                    if (j < 0 || j >= m) continue;

                    if (matrix[y, x].CompareTo(matrix[i, j]) == 0 && (centerX != j || centerY != i))
                    {
                        if (i < y && j < x) dir = Direction.NorthWest;
                        else if (i < y && j == x) dir = Direction.North;
                        else if (i < y && j > x) dir = Direction.NorthEast;
                        else if (i == y && j < x) dir = Direction.West;
                        else if (i == y && j > x) dir = Direction.East;
                        else if (i > y && j < x) dir = Direction.SouthWest;
                        else if (i > y && j == x) dir = Direction.South;
                        else if (i > y && j > x) dir = Direction.SouthEast;

                        CalculateCount(matrix, y, x, n, m, ref count, ref seqStr, dir);
                    }
                }
            }
        }

        static void CalculateCount(string[,] matrix, int y, int x, int n, int m, ref int count, ref string seqStr, Direction dir)
        {
            int currentCount = 0;
            int startX = x, startY = y;
            switch (dir)
            {
                case Direction.NorthWest:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        y--;
                        x--;
                        currentCount++;
                    }
                    break;
                case Direction.North:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        y--;
                        currentCount++;
                    }
                    break;
                case Direction.NorthEast:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        y--;
                        x++;
                        currentCount++;
                    }
                    break;
                case Direction.East:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        x++;
                        currentCount++;
                    }
                    break;
                case Direction.West:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        x--;
                        currentCount++;
                    }
                    break;
                case Direction.SouthWest:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        y++;
                        x--;
                        currentCount++;
                    }
                    break;
                case Direction.South:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        y++;
                        currentCount++;
                    }
                    break;
                case Direction.SouthEast:
                    while (y >= 0 && y < n && x >= 0 && x < m && matrix[y, x].CompareTo(matrix[startY, startX]) == 0)
                    {
                        y++;
                        x++;
                        currentCount++;
                    }
                    break;
            }

            if (currentCount > count)
            {
                count = currentCount;
                seqStr = matrix[startY, startX];
            }
        }
    }
}
