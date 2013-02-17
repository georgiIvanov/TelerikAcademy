using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13.TaskSolver
{
    class TaskSolver
    {
        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("Enter number of chosen task: ");
                Console.WriteLine("1. Reverse digits of number");
                Console.WriteLine("2. Calculate average of a sequence of integers");
                Console.WriteLine("3. Solve equation - a*x + b = 0");
                Console.WriteLine("4. Exit");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1: ReverseNumber(); break;
                    case 2: AverageOfIntegers(); break;
                    case 3: SolveLinearEquation(); break;
                }
                Console.WriteLine();
            }


        }

        static void ReverseNumber()
        {
            Console.WriteLine("Enter number: ");
            string number = Console.ReadLine();

            char[] reversingArray = number.ToCharArray();
            Array.Reverse(reversingArray);

            number = new string(reversingArray);

            Console.WriteLine(number);
        }

        static void AverageOfIntegers()
        {
            Console.WriteLine("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            Console.WriteLine("Enter {0} numbers, each on new line: ", n);
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            double average = 0;
            for (int i = 0; i < n; i++)
            {
                average += numbers[i];
            }

            average /= n;

            Console.WriteLine("Average is: {0}", average);

        }

        static void SolveLinearEquation()
        {
            Console.WriteLine("Enter coeficients {0}*x + {1} = 0, each on new line");
            double a, b;

            if (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("a is not correct"); return;
            }
            if (!double.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("b is not correct"); return;
            }
            if (a == 0)
            {
                Console.WriteLine("a cannot be 0");
                return;
            }

            b *= -1;
            b /= a;
            Console.WriteLine("x is {0}", b);
        }
    }
}
