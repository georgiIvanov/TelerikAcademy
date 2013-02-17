using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.PrintMatrix
{
    class PrintMatrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of matrix N: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int nSquare = n * n;
            int number = 1;
            int i = 0, j = 0;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    matrix[i, j] = number;
                    number++;
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("{0}\t",matrix[j, i]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            number = 1;
            j = 0;
            for (i = 0; i < n; i++)
            {
                if ((i & 1) == 0)
                {
                    for (; j < n; j++)
                    {
                        matrix[i, j] = number;
                        number++;
                    }
                    j--;
                }
                else
                {
                    for (; j >= 0; j--)
                    {
                        matrix[i, j] = number;
                        number++;
                    }
                    j++;
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("{0}\t", matrix[j, i]);
                }
                Console.WriteLine();
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            Console.WriteLine();
            i = n - 1;
            number = 1;
            int k = 0;
            int row = 0, jStart = 1;;
            for (; i >= 0 || number != nSquare + 1; i--)
            {
                row = i + k;
                j = k;
                if (i <= 0)
                {
                    i = 0;
                    k++;
                    row = 0;
                }
                
                for (; j < n && row < n; j++)
                {
                    matrix[row, j] = number;
                    number++;
                    row++;
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Spiral(n, matrix, number);

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("{0}\t", matrix[j, i]);
                }
                Console.WriteLine();
            }
        }

        private static void Spiral(int n, int[,] matrix, int number)
        {
            number = 1;
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i; j++)
                {
                    matrix[i, j] = number;
                    number++;
                }


                for (int j = 0; j < n - 1 - i * 2; j++)
                {
                    matrix[j + 1 + i, n - i - 1] = number;
                    number++;
                }


                for (int j = 0; j < n - 1 - i * 2; j++)
                {
                    matrix[n - i - 1, n - j - 2 - i] = number;
                    number++;
                }


                for (int j = 0; j < n - 2 - i * 2; j++)
                {
                    matrix[n - j - 2 - i, i] = number;
                    number++;
                }
            }
        }
    }
}
