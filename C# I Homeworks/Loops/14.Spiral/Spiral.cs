using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14.Spiral
{
    //further down the 
    class Spiral
    {
        static void Main(string[] args)
        {
            int n, num = 1, side = 0;

            n = int.Parse(Console.ReadLine());

            //finds side of the square
            for (int i = 1; i < n; i++)
            {
                if (n <= i * i)
                {
                    side = i;
                    break;
                }
            }

            int[,] matrix = new int[side, side];

            for (int i = 0; i < side / 2; i++)
            {
                for (int j = i; j < side - i; j++)
			    {
                    matrix[i,j] = num;
                    num++;
			    }


                for (int j = 0; j < side - 1 - i * 2; j++)
                {
                    matrix[j + 1 + i, side - i - 1] = num;
                    num++;
                }


                for (int j = 0; j < side - 1 - i * 2; j++)
                {
                    matrix[side - i - 1, side - j - 2 - i] = num;
                    num++;
                }


                for (int j = 0; j < side - 2 - i * 2; j++)
                {
                    matrix[side - j - 2 - i, i] = num;
                    num++;
                }
            }

            Console.WriteLine();
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    else
                    {
                        Console.Write("\t");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            


        }
    }
}
