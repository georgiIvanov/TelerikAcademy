using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08.GenericMatrix
{
    class AddIndexer
    {
        static void Main(string[] args)
        {
            Matrix<double> matrix = new Matrix<double>(3);
            Random rng = new Random();

            for (int i = 0; i < matrix.matrixDimension; i++)
            {
                for (int j = 0; j < matrix.matrixDimension; j++)
                {
                    matrix[i, j] = rng.Next(1, 100);
                }
            }
            Console.WriteLine(matrix[1,1]);
            
        }
    }

    class Matrix<T>
    {
        private T[,] matrix;
        public int matrixDimension
        {
            get;
            set;
        }
        
        public Matrix(int dimensions)
        {
            matrix = new T[dimensions, dimensions];
            matrixDimension = dimensions;
        }

        public T this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
    }
}
