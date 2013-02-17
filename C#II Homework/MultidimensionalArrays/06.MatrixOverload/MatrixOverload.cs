using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.MatrixOverload
{
    class MatrixOverload
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix side: ");
            int n = int.Parse(Console.ReadLine());
            Matrix m1 = new Matrix(n);
            Matrix m2 = new Matrix(n);

            Console.WriteLine("Enter numbers for matrix 1, each on new line: ");
            m1.SetMatrix();

            Console.WriteLine("Enter numbers for matrix 2, each on new line: ");
            m2.SetMatrix();

            Console.WriteLine();
            Console.WriteLine("Matrix1.ToString(): ");
            Console.WriteLine(m1.ToString());

            Console.WriteLine();
            Console.WriteLine("Matrix2.ToString(): ");
            Console.WriteLine(m2.ToString());

            Console.WriteLine();
            Console.WriteLine("Matrix1 + Matrix2 addition ");
            Console.WriteLine((m1+m2).ToString());

            Console.WriteLine();
            Console.WriteLine("Matrix1 - Matrix2 subtraction ");
            Console.WriteLine((m1 - m2).ToString());

            Console.WriteLine();
            Console.WriteLine("Matrix1*Matrix2 multiplication ");
            Console.WriteLine((m1 * m2).ToString());

            Console.WriteLine();
            Console.WriteLine("Matrix1*Number({0}) multiplication ", n);
            Console.WriteLine((m1 * n).ToString());

        }
    }

    struct Matrix
    {
        int[,] matrix;
        static int matrixSide;
        public Matrix(int n)
        {
            matrix = new int[n, n];
            matrixSide = n;

        }

        public void SetMatrix()
        {
            for (int i = 0; i < matrixSide; i++)
            {
                for (int j = 0; j < matrixSide; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix mNew = m1;
            for (int i = 0; i < matrixSide; i++)
            {
                for (int j = 0; j < matrixSide; j++)
                {
                    mNew[i, j] += m2[i, j];
                }
            }

            return mNew;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix mNew = m1;
            for (int i = 0; i < matrixSide; i++)
            {
                for (int j = 0; j < matrixSide; j++)
                {
                    mNew[i, j] -= m2[i, j];
                }
            }

            return mNew;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix mNew = m1;
            for (int i = 0; i < matrixSide; i++)
            {
                for (int j = 0; j < matrixSide; j++)
                {
                    mNew[i, j] *= m2[i, j];
                }
            }

            return mNew;
        }

        public static Matrix operator *(Matrix m1, int num)
        {
            Matrix mNew = m1;
            for (int i = 0; i < matrixSide; i++)
            {
                for (int j = 0; j < matrixSide; j++)
                {
                    mNew[i, j] *= num;
                }
            }

            return mNew;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrixSide; i++)
            {
                for (int j = 0; j < matrixSide; j++)
                {
                    sb.AppendFormat("{0}\t", matrix[i, j]);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
