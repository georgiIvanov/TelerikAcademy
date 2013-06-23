using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Salaries
{
    class Program
    {
        static int vertices;
        static bool[,] adjMatrix;
        static long[] cache;

        static long FindSalary(int employee)
        {
            if (cache[employee] > 0)
            {
                return cache[employee];
            }

            long salary = 0;
            for (int i = 0; i < vertices; i++)
            {
                if (adjMatrix[employee, i])
                {
                    salary += FindSalary(i);
                }
            }
            if (salary == 0)
            {
                salary = 1;
            }
            return salary;
        }

        static void Main(string[] args)
        {
            vertices = int.Parse(Console.ReadLine());
            adjMatrix = new bool[vertices, vertices];
            cache = new long[vertices];

            for (int i = 0; i < vertices; i++)
            {
                string inputLine = Console.ReadLine();
                for (int j = 0; j < vertices; j++)
                {
                    adjMatrix[i, j] = (inputLine[j] == 'Y');
                }
            }

            long sumOfSalaries = 0;
            for (int i = 0; i < vertices; i++)
            {
                sumOfSalaries += FindSalary(i);
            }
            Console.WriteLine(sumOfSalaries);
        }
    }
}
