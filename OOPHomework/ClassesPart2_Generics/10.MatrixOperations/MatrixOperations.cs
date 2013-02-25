using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08.GenericMatrix
{
    class MatrixOperations
    {
        static void Main(string[] args)
        {
            Matrix<double> matrix1  = new Matrix<double>(3);
            Matrix<double> matrix2 = new Matrix<double>(3);
            Matrix<double> newMatrix;
            Random rng = new Random();

            for (int i = 0; i < matrix1.matrixDimension; i++)
            {
                for (int j = 0; j < matrix1.matrixDimension; j++)
                {
                    matrix1[i, j] = rng.Next(-2, 8);
                }
            }

            for (int i = 0; i < matrix2.matrixDimension; i++)
            {
                for (int j = 0; j < matrix2.matrixDimension; j++)
                {
                    matrix2[i, j] = rng.Next(-2, 8);
                }
            }

            //show matrices
            //show first matrix
            for (int i = 0; i < matrix1.matrixDimension; i++)
            {
                for (int j = 0; j < matrix1.matrixDimension; j++)
                {
                    Console.Write("{0}\t", matrix1[i,j]);
                }
                Console.WriteLine();
            }

            //show second matrix
            Console.WriteLine();
            for (int i = 0; i < matrix2.matrixDimension; i++)
            {
                for (int j = 0; j < matrix2.matrixDimension; j++)
                {
                    Console.Write("{0}\t", matrix2[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            newMatrix = matrix1 + matrix2;

            for (int i = 0; i < newMatrix.matrixDimension; i++)
            {
                for (int j = 0; j < newMatrix.matrixDimension; j++)
                {
                    Console.Write("{0}\t", newMatrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            newMatrix = matrix1 - matrix2;

            for (int i = 0; i < newMatrix.matrixDimension; i++)
            {
                for (int j = 0; j < newMatrix.matrixDimension; j++)
                {
                    Console.Write("{0}\t", newMatrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            newMatrix = matrix1 * matrix2;

            for (int i = 0; i < newMatrix.matrixDimension; i++)
            {
                for (int j = 0; j < newMatrix.matrixDimension; j++)
                {
                    Console.Write("{0}\t", newMatrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            if (matrix1)
            {
                Console.WriteLine("First matrix contains a zero");
            }
            else
            {
                Console.WriteLine("First matrix doesnt contain a zero");
            }

        }
    }

    class Matrix<T> where T : IComparable
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

        Matrix(int dimensions, Matrix<T> newM)
        {
            matrix = new T[dimensions, dimensions];
            matrixDimension = dimensions;

            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    matrix[i, j] = newM[i, j];
                }
            }
        }

        public T this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> mNew = m1.matrixDimension > m2.matrixDimension ? m1 : m2;
            mNew = new Matrix<T>(mNew.matrixDimension, mNew);

            for (int i = 0; i < m1.matrixDimension && i < m2.matrixDimension; i++)
            {
                for (int j = 0; j < m1.matrixDimension && j < m2.matrixDimension; j++)
                {
                    dynamic a = m1[i, j];
                    dynamic b = m2[i, j];
                    mNew[i,j] = a + b;
                }
            }

            return mNew;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> mNew = m1.matrixDimension > m2.matrixDimension ? m1 : m2;
            mNew = new Matrix<T>(mNew.matrixDimension, mNew);

            if (m1.matrixDimension > m2.matrixDimension)
            {
                for (int i = 0; i < m1.matrixDimension && i < m2.matrixDimension; i++)
                {
                    for (int j = 0; j < m1.matrixDimension && j < m2.matrixDimension; j++)
                    {
                        dynamic a = m1[i, j];
                        dynamic b = m2[i, j];
                        mNew[i, j] = a - b;
                    }
                }
            }
            else
            {
                for (int i = 0; i < m1.matrixDimension && i < m2.matrixDimension; i++)
                {
                    for (int j = 0; j < m1.matrixDimension && j < m2.matrixDimension; j++)
                    {
                        dynamic a = m1[i, j];
                        dynamic b = m2[i, j];
                        mNew[i, j] = b - a;
                    }
                }
            }
            return mNew;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.matrixDimension != m2.matrixDimension)
            {
                throw new ArithmeticException("Matrices cant be multiplicated");
            }

            Matrix<T> mNew = new Matrix<T>(m1.matrixDimension);

            for (int h = 0; h < m1.matrixDimension; h++)
            {
                    for (int i = 0, j = 0; i < m1.matrixDimension; i++)
                    {
                        dynamic sum = 0;
                        for (j = 0; j < m1.matrixDimension; j++)
                        {
                            dynamic a = m1[h, j];
                            dynamic b = m2[j, i];
                            sum += a * b;
                            //mNew[i, j] = a * b;
                        }
                        mNew[h, i] = sum;
                    }
            }
            return mNew;
        }

        public static bool operator true(Matrix<T> mat)
        {
            for (int i = 0; i < mat.matrixDimension; i++)
            {
                for (int j = 0; j < mat.matrixDimension; j++)
                {
                    dynamic a = mat[i, j];
                    if (a == 0) return true;
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> mat)
        {
            for (int i = 0; i < mat.matrixDimension; i++)
            {
                for (int j = 0; j < mat.matrixDimension; j++)
                {
                    dynamic a = mat[i, j];
                    if (a == 0) return false;
                }
            }
            return true;
        }
    }
}

