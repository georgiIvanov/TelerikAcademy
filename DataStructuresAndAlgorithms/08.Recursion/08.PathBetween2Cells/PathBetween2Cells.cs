using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathBetween2Cells
{
    class PathBetween2Cells
    {
        


        static void Main(string[] args)
        {
            string[,] labyrinth = 
            {
                {" ", " ", " ", "*", " ", " ", " "},
                {"*", "*", " ", "*", " ", "*", " "},
                {" ", " ", " ", " ", " ", " ", " "},
                {" ", "*", "*", "*", "*", "*", " "},
                {" ", " ", " ", " ", " ", " ", " "},
            };
            
            //entry coords
            int row = 4;
            int col = 0;

            string[,] emptyLabyrinth = InitEmptyLabyrinth(100, 100);

            SetExit(emptyLabyrinth, 0, 6);
            bool found = false;
            FindExit(emptyLabyrinth, row, col, 0, ref found);
        }

        static void FindExit(string[,] labyrinth, int row, int col, int step, ref bool found)
        {
            if (row < 0 || col < 0 || found ||
                row >= labyrinth.GetLength(0) || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[row, col] == "e")
            {
                PrintLabyrint(labyrinth);
                found = true;
                Console.WriteLine("Exit found at [{0},{1}]", row, col);
            }

            if (labyrinth[row, col] != " ")
            {
                return;
            }

            labyrinth[row, col] = step.ToString();
            step++;

            FindExit(labyrinth, row, col - 1, step, ref found);
            FindExit(labyrinth, row - 1, col, step, ref found);
            FindExit(labyrinth, row, col + 1, step, ref found);
            FindExit(labyrinth, row + 1, col, step, ref found);

            labyrinth[row, col] = " ";
        }

        static void SetExit(string[,] labyrinth, int row, int col)
        {
            labyrinth[row, col] = "e";
        }

        static void PrintLabyrint(string[,] labyrinth)
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

        static string[,] InitEmptyLabyrinth(int rows, int cols)
        {
            string[,] labyrinth = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    labyrinth[i, j] = " ";
                }
            }

            return labyrinth;
        }
    }
}
