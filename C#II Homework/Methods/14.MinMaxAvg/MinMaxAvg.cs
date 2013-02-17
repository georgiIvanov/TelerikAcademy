using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14.MinMaxAvg
{
    class MinMaxAvg
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            Console.WriteLine("Enter {0} numbers, each on new line: ", n);
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int min = GetMin(numbers);
            Console.WriteLine("Minimal number is: {0}", min);
            int max = GetMax(numbers);
            Console.WriteLine("Maximal number is: {0}", max);
            int avg = GetAverage(numbers);
            Console.WriteLine("Average value is: {0}", avg);
            int sum = SumOfElements(numbers);
            Console.WriteLine("Sum of all elements: {0}", sum);
            int prod = ProductOfElements(numbers);
            Console.WriteLine("Product of all elements: {0}", prod);

            

        }

        static int GetMin(int[] numbers)
        {
            int min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        static int GetMax(int[] numbers)
        {
            int max = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        static int GetAverage(int[] numbers)
        {
            int average = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                average += numbers[i];
            }
            average /= numbers.Length;

            return average;
        }

        static int SumOfElements(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        static int ProductOfElements(int[] numbers)
        {
            int prod = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                prod *= numbers[i];
            }

            return prod;
        }
    }
}
