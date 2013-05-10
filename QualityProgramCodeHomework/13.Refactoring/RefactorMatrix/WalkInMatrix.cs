using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMatrix
{
    public class WalkInMatrix
    {
        int[,] matrix;
        int[] directionsX;
        int[] directionsY;
        int number, directionX, directionY, matrixSize,
            row, col;

        public WalkInMatrix(int size)
        {
            matrix = new int[size, size];
            matrixSize = size;
            number = 1;
            directionX = 1;
            directionY = 1;
            row = 0;
            col = 0;

            InitializeDirections();
        }

        private void InitializeDirections()
        {
            directionsX = new int[] { 1, 1, 1, 0, -1, -1, -1, 0 };
            directionsY = new int[] { 1, 0, -1, -1, -1, 0, 1, 1 };
        }

        void ChangeDirection()
        {
            InitializeDirections();

            int cd = 0;

            for (int i = 0; i < 8; i++)
            {
                if (directionsX[i] == directionX && directionsY[i] == directionY)
                {
                    cd = i;
                    break;
                }
            }

            if (cd == 7)
            {
                directionX = directionsX[0];
                directionY = directionsY[0];
            }
            else
            {
                directionX = directionsX[cd + 1];
                directionY = directionsY[cd + 1];
            }
        }

        bool IsMovePossible()
        {
            InitializeDirections();

            for (int i = 0; i < 8; i++)
            {
                if (row + directionsX[i] >= matrixSize || row + directionsX[i] < 0)
                {
                    directionsX[i] = 0;
                }

                if (col + directionsY[i] >= matrixSize || col + directionsY[i] < 0)
                {
                    directionsY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[row + directionsX[i], col + directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        bool FindZeroValueCoords()
        {
            row = 0;
            col = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return true;
                    }
                }
            }

            return false;
        }

        private void FillUntilNoDirectionsAreValid()
        {
            while (true)
            {
                matrix[row, col] = number;

                if (!IsMovePossible())
                {
                    break;
                }

                if (IsCurrentDirectionBlind())
                {
                    while (FindValidDirection())
                    {
                        ChangeDirection();
                    }
                }
                row += directionX;
                col += directionY;
                number++;
            }
        }

        private bool IsCurrentDirectionBlind()
        {
            return row + directionX >= matrixSize || row + directionX < 0 ||
                   col + directionY >= matrixSize || col + directionY < 0 || matrix[row + directionX,
                   col + directionY] != 0;
        }

        private bool FindValidDirection()
        {
            return row + directionX >= matrixSize || row + directionX < 0 ||
                   col + directionY >= matrixSize || col + directionY < 0 ||
                   matrix[row + directionX, col + directionY] != 0;
        }

        public void FillMatrix()
        {
            FillUntilNoDirectionsAreValid();

            while (FindZeroValueCoords())
            {
                number++;
                directionX = 1;
                directionY = 1;

                FillUntilNoDirectionsAreValid();
            }
        }

        public int[,] GetMatrix
        {
            get
            {
                return (int[,])this.matrix.Clone();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result.AppendFormat("{0,3}", matrix[i, j]);
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
