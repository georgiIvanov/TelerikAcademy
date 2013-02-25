using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08.GenericMatrix
{
    class MatrixOperationsAlternative
    {
        static void Main(string[] args)
        {
            Matrix<double, DoubleOperations> matrix1 = new Matrix<double, DoubleOperations>(3);
            Matrix<double, DoubleOperations> matrix2 = new Matrix<double, DoubleOperations>(3);
            Matrix<double, DoubleOperations> newMatrix;
            Random rng = new Random();

            //decimal initialization
            //Matrix<decimal, DecimalOperations> matrix1 = new Matrix<decimal, DecimalOperations>(3);
            //Matrix<decimal, DecimalOperations> matrix2 = new Matrix<decimal, DecimalOperations>(3);
            //Matrix<decimal, DecimalOperations> newMatrix;
            //for (int i = 0; i < matrix1.matrixDimension; i++)
            //{
            //    for (int j = 0; j < matrix1.matrixDimension; j++)
            //    {
            //        matrix1[i, j] = (decimal)rng.NextDouble() * 10;
            //    }
            //}

            //for (int i = 0; i < matrix2.matrixDimension; i++)
            //{
            //    for (int j = 0; j < matrix2.matrixDimension; j++)
            //    {
            //        matrix2[i, j] = (decimal)rng.NextDouble() * 10;
            //    }
            //}
            //int initialization
            //Matrix<int, IntOperations> matrix1 = new Matrix<int, IntOperations>(3);
            //Matrix<int, IntOperations> matrix2 = new Matrix<int, IntOperations>(3);
            //Matrix<int, IntOperations> newMatrix;

            //for (int i = 0; i < matrix1.matrixDimension; i++)
            //{
            //    for (int j = 0; j < matrix1.matrixDimension; j++)
            //    {
            //        matrix1[i, j] = rng.Next(1, 10);
            //    }
            //}

            //for (int i = 0; i < matrix2.matrixDimension; i++)
            //{
            //    for (int j = 0; j < matrix2.matrixDimension; j++)
            //    {
            //        matrix2[i, j] = rng.Next(1, 10);
            //    }
            //}

            for (int i = 0; i < matrix1.matrixDimension; i++)
            {
                for (int j = 0; j < matrix1.matrixDimension; j++)
                {
                    matrix1[i, j] = rng.NextDouble() * 10;
                }
            }

            for (int i = 0; i < matrix2.matrixDimension; i++)
            {
                for (int j = 0; j < matrix2.matrixDimension; j++)
                {
                    matrix2[i, j] = rng.NextDouble() * 10;
                }
            }

            //show matrices
            //show first matrix
            for (int i = 0; i < matrix1.matrixDimension; i++)
            {
                for (int j = 0; j < matrix1.matrixDimension; j++)
                {
                    Console.Write("{0:F2}\t", matrix1[i, j]);
                }
                Console.WriteLine();
            }

            //show second matrix
            Console.WriteLine();
            for (int i = 0; i < matrix2.matrixDimension; i++)
            {
                for (int j = 0; j < matrix2.matrixDimension; j++)
                {
                    Console.Write("{0:F2}\t", matrix2[i, j]);
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
                    Console.Write("{0:F2}\t", newMatrix[i, j]);
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
                    Console.Write("{0:F2}\t", newMatrix[i, j]);
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
                    Console.Write("{0:F2}\t", newMatrix[i, j]);
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

    interface IArithmetic<T>
    {
        T Sum(T a, T b);
        T Subtract(T a, T b);
        T Multiply(T a, T b);
        bool IsZero(T a);
    }

    struct IntOperations : IArithmetic<int>
    {
        public int Sum(int a, int b) { return a + b; }
        public int Subtract(int a, int b) { return a - b; }
        public int Multiply(int a, int b) { return a * b; }
        public bool IsZero(int a)
        {
            if (a == 0) return true;
            else return false;
        }
    }
    struct DoubleOperations : IArithmetic<double>
    {
        public double Sum(double a, double b) { return a + b; }
        public double Subtract(double a, double b) { return a - b; }
        public double Multiply(double a, double b) { return a * b; }
        public bool IsZero(double a)
        {
            if (a == 0) return true;
            else return false;
        }
    }
    struct DecimalOperations : IArithmetic<decimal>
    {
        public decimal Sum(decimal a, decimal b) { return a + b; }
        public decimal Subtract(decimal a, decimal b) { return a - b; }
        public decimal Multiply(decimal a, decimal b) { return a * b; }
        public bool IsZero(decimal a)
        {
            if (a == 0) return true;
            else return false;
        }
    }
    struct FloatOperations : IArithmetic<float>
    {
        public float Sum(float a, float b) { return a + b; }
        public float Subtract(float a, float b) { return a - b; }
        public float Multiply(float a, float b) { return a * b; }
        public bool IsZero(float a)
        {
            if (a == 0) return true;
            else return false;
        }
    }

    class Matrix<T, C> where T : IComparable
                       where C : IArithmetic<T>, new()
    {
        private static C calculator = new C();
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

        public static Matrix<T, C> operator +(Matrix<T, C> m1, Matrix<T, C> m2)
        {
            if (m1.matrixDimension != m2.matrixDimension) throw new ArgumentException("matrices have different sizes");
            Matrix<T, C> mNew = new Matrix<T, C>(m1.matrixDimension);

            for (int i = 0; i < m1.matrixDimension; i++)
            {
                for (int j = 0; j < m1.matrixDimension; j++)
                {
                    mNew[i, j] = calculator.Sum(m1[i, j], m2[i, j]);
                }
            }

            return mNew;
        }

        public static Matrix<T, C> operator -(Matrix<T, C> m1, Matrix<T, C> m2)
        {
            if (m1.matrixDimension != m2.matrixDimension) throw new ArgumentException("matrices have different sizes");
            Matrix<T, C> mNew = new Matrix<T, C>(m1.matrixDimension);

            for (int i = 0; i < m1.matrixDimension; i++)
            {
                for (int j = 0; j < m1.matrixDimension; j++)
                {
                    mNew[i, j] = calculator.Subtract(m1[i, j], m2[i, j]);
                }
            }
            return mNew;
        }

        public static Matrix<T, C> operator *(Matrix<T, C> m1, Matrix<T, C> m2)
        {
            if (m1.matrixDimension != m2.matrixDimension) throw new ArgumentException("matrices have different sizes");
            Matrix<T, C> mNew = new Matrix<T, C>(m1.matrixDimension);

            for (int h = 0; h < m1.matrixDimension; h++)
            {
                for (int i = 0, j = 0; i < m1.matrixDimension; i++)
                {
                    T sum = default(T);
                    for (j = 0; j < m1.matrixDimension; j++)
                    {
                        sum = calculator.Sum(sum, calculator.Multiply(m1[h, j], m2[j, i]));
                    }
                    mNew[h, i] = sum;
                }
            }
            return mNew;
        }

        public static bool operator true(Matrix<T, C> mat)
        {
            for (int i = 0; i < mat.matrixDimension; i++)
            {
                for (int j = 0; j < mat.matrixDimension; j++)
                {
                    if (calculator.IsZero(mat[i, j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T, C> mat)
        {
            for (int i = 0; i < mat.matrixDimension; i++)
            {
                for (int j = 0; j < mat.matrixDimension; j++)
                {
                    if (calculator.IsZero(mat[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

