using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GenericMatrix
{
    class GenericMatrix
    {
        static void Main(string[] args)
        {
            Matrix<double> matrix = new Matrix<double>(3);
            Random rng = new Random();

            for (int i = 0; i <= matrix.matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.matrix.GetUpperBound(1); j++)
                {
                    matrix.matrix[i, j] = rng.Next(1, 100);
                }
            }

            for (int i = 0; i <= matrix.matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.matrix.GetUpperBound(1); j++)
                {
                    Console.Write("{0}\t", matrix.matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }

    class Matrix<T>
    {
        public T[,] matrix;
        public Matrix(int dimensions)
        {
            matrix = new T[dimensions, dimensions];
        }

    }
}
