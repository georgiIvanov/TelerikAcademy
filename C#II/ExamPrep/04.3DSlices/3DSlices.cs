using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._3DSlices
{
    class Slices3D
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            string[] dimensions = inputLine.Split(' ');

            int width = int.Parse(dimensions[0]);
            int height = int.Parse(dimensions[1]);
            int depth = int.Parse(dimensions[2]);
            long totalSum = 0;

            int[,,] cube = new int[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split('|');

                for (int d = 0; d < depth; d++)
                {
                    string[] numbers = tokens[d].Split(new char[] {' '}, 
                        StringSplitOptions.RemoveEmptyEntries);

                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = int.Parse(numbers[w]);
                        totalSum += int.Parse(numbers[w]);
                    }
                }
            }


            long sum = 0;
            int count = 0;


            for (int w = 0; w < width - 1; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        sum += cube[w, h, d];
                    }
                }

                if (sum * 2 == totalSum)
                {
                    count++;
                }
            }

            sum = 0;
            for (int h = 0; h < height - 1; h++)
            {
                for (int d = 0; d < depth; d++) 
                {
                    for (int w = 0; w < width; w++)
                    {
                        sum += cube[w, h, d];
                    }
                }

                if (sum * 2 == totalSum)
                {
                    count++;
                }
            }


            sum = 0;
            for (int d = 0; d < depth - 1; d++)
            {
                for (int w = 0; w < width; w++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        sum += cube[w, h, d];
                    }
                }

                if (sum * 2 == totalSum)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
