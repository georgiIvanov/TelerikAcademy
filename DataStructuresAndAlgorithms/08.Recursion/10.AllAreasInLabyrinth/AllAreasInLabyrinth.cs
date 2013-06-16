using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.AllAreasInLabyrinth
{
    class AllAreasInLabyrinth
    {
        static string[,] labyrinth = 
        {
            {" ", " ", " ", "*", " ", " ", " "},
            {"*", "*", " ", "*", " ", "*", " "},
            {" ", " ", " ", "*", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", "*", " ", " ", " "},
        };

        static void Main(string[] args)
        {
            FindBiggestArea(labyrinth.GetLength(0), labyrinth.GetLength(1));
        }

        static void FindBiggestArea(int rows, int cols)
        {
            int step = 0;
            int count = 0;

            PrintLabyrint();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (labyrinth[i, j] == " ")
                    {
                        FindArea(i, j, step, ref count);
                        step++;
                        PrintLabyrint();
                    }
                }
            }
        }

        static void FindArea(int row, int col, int step, ref int count)
        {
            if (row < 0 || col < 0 ||
                row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[row, col] != " ")
            {
                return;
            }

            labyrinth[row, col] = step.ToString();
            count++;

            FindArea(row, col - 1, step, ref count);
            FindArea(row - 1, col, step, ref count);
            FindArea(row, col + 1, step, ref count);
            FindArea(row + 1, col, step, ref count);
        }

        static void PrintLabyrint()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write("{0, 2} ", labyrinth[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
