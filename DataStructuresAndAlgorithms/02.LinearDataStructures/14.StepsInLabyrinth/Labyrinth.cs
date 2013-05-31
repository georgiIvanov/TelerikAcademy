using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.StepsInLabyrinth
{
    class Labyrinth
    {
        string[,] field;
        static int[,] directions =
        {
            {0, 1},
            {1, 0},
            {0, -1},
            {-1, 0},
        };
        int height, width;
        Cell startingCell;

        public Labyrinth(string[,] inputField)
        {
            this.field = inputField;
            this.height = field.GetLength(0);
            this.width = field.GetLength(1);
            startingCell = FindStartingCell();
        }

        Cell FindStartingCell()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i, j] == "*")
                    {
                        return new Cell(i, j, 0);
                    }
                }
            }
            throw new InvalidOperationException("Invalid field, no starting point");
        }

        public void FindSteps()
        {
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(startingCell);
            while (queue.Count > 0)
            {
                Cell currentCell = queue.Dequeue();

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    int nextRow = currentCell.Row + directions[i, 0];
                    int nextCol = currentCell.Col + directions[i, 1];

                    if (StepPossible(nextRow, nextCol))
                    {
                        Cell nextStep = new Cell(nextRow, nextCol, currentCell.Value + 1);

                        field[nextStep.Row, nextStep.Col] = nextStep.Value.ToString();
                        queue.Enqueue(nextStep);
                    }
                }
            }

            MarkUnpassable();
        }

        private void MarkUnpassable()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (field[i, j] == "0")
                    {
                        field[i, j] = "u";
                    }
                }
            }
        }

        private bool StepPossible(int row, int col)
        {
            return (row < height && row >= 0 && col < width && col >= 0 &&
                field[row, col] == "0") ? true : false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sb.AppendFormat("{0, -3}", field[i, j]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
