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

            
            double dnum;
            int inum;
            Console.WriteLine("Enter {0} numbers, each on new line: ", n);
            string input = Console.ReadLine();
            if (double.TryParse(input, out dnum))
            {
                double[] dnumbers = new double[n];
                dnumbers[0] = double.Parse(input);
                for (int i = 1; i < n; i++)
                {
                    dnumbers[i] = double.Parse(Console.ReadLine());
                }
                GetMin(dnumbers, n);
                GetMax(dnumbers, n);

            }
            else
            {
                int[] numbers = new int[n];
                numbers[0] = int.Parse(input);

                for (int i = 1; i < n; i++)
                {
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                GetMin(numbers, n);
                GetMax(numbers, n);
            }
            

            
            //GetAverage(numbers);
            //int sum = SumOfElements(numbers);
            //Console.WriteLine("Sum of all elements: {0}", sum);
            //int prod = ProductOfElements(numbers);
            //Console.WriteLine("Product of all elements: {0}", prod);



        }

        static void GetMin<T>(T[] numbers, int length) where T : IComparable<T>
        {
            T min = numbers[0];
            for (int i = 0; i < length; i++)
            {
                if (numbers[i].CompareTo(min) < 0)
                {
                    min = numbers[i];
                }
            }

            Console.WriteLine("Min number is: {0}", min.ToString());
        }

        static void GetMax<T>(T[] numbers, int length) where T : IComparable<T>
        {
            T max = numbers[0];
            for (int i = 0; i < length; i++)
            {
                if (numbers[i].CompareTo(max) > 0)
                {
                    max = numbers[i];
                }
            }

            Console.WriteLine("Max number is: {0}", max.ToString());
        }

        //static void GetAverage<T>(T[] numbers)
        //{
        //    GenericInt average = numbers[0];
        //    for (int i = 1; i < numbers.Length; i++)
        //    {
        //        average = average.Add(average, numbers[i]);
        //    }
        //    average = average.Divide(average, new GenericInt(numbers.Length));

        //    Console.WriteLine("Average number is: {0}", average.ToString());
        //}

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

    class GenericInt
    {
        private int m_Int;

        public GenericInt(int a)
        {
            m_Int = a;
        }

        public GenericInt Add(GenericInt a, GenericInt b)
        {
            return new GenericInt(a.m_Int + b.m_Int);
        }

        public GenericInt Divide(GenericInt a, GenericInt b)
        {
            return new GenericInt(a.m_Int / b.m_Int);
        }

        public override string ToString()
        {
            return m_Int.ToString();
        }
    }
}
