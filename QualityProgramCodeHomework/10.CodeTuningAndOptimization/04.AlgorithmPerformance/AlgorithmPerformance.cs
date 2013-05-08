using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AlgorithmPerformance
{
    class AlgorithmPerformance
    {
        const int ArrayLength = 10000;
        const int stringLength = 15;
        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            double[] doubleArray = RandomArrayGenerator.RandomArray<double>(ArrayLength, double.MinValue, double.MaxValue);
            int[] intArray = RandomArrayGenerator.RandomArray<int>(ArrayLength, int.MinValue, int.MaxValue);
            string[] stringArray = RandomArrayGenerator.RandomStringArray(ArrayLength, 1, stringLength);

            Console.WriteLine("Results in msec, random arrays: \n");
            Console.WriteLine("\tInsertionSort\tSelectionSort\tQuickSort");

            MeasureSortTime<double>("doubl[]", doubleArray);
            MeasureSortTime<int>("int[]",intArray);
            MeasureSortTime<string>("str[]", stringArray);



            double[] orderedDouble = (double[])doubleArray.Clone();
            SortingAlgorithm.Quicksort<double>(orderedDouble, 0, orderedDouble.Length - 1);
            int[] orderedInt = (int[])intArray.Clone();
            SortingAlgorithm.Quicksort<int>(orderedInt, 0, orderedInt.Length - 1);
            string[] orderedString = (string[])stringArray.Clone();
            SortingAlgorithm.Quicksort<string>(orderedString, 0, orderedString.Length - 1);
            
            Console.WriteLine("\n\nResults in msec, ordered arrays: \n");
            Console.WriteLine("\tInsertionSort\tSelectionSort\tQuickSort");

            MeasureSortTime<double>("doubl[]", orderedDouble);
            MeasureSortTime<int>("int[]", orderedInt);
            MeasureSortTime<string>("str[]", orderedString);



            Console.WriteLine("\n\nResults in msec, reversed arrays: \n");
            Console.WriteLine("\tInsertionSort\tSelectionSort\tQuickSort");

            MeasureSortTime<double>("doubl[]", orderedDouble.Reverse<double>().ToArray<double>());
            MeasureSortTime<int>("int[]", orderedInt.Reverse<int>().ToArray<int>());
            MeasureSortTime<string>("str[]", orderedString.Reverse<string>().ToArray<string>());

        }

        static void MeasureSortTime<T>(string arrayType, T[] array) where T : IComparable<T>
        {
            T[] insertionSort = (T[])array.Clone();
            T[] selectionSort = (T[])array.Clone();
            T[] quickSort = (T[])array.Clone();

            stopwatch.Start();
            SortingAlgorithm.InsertionSort<T>(insertionSort);
            stopwatch.Stop();
            Console.Write("{0}\t{1:F3}\t", arrayType, stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            SortingAlgorithm.SelectionSort<T>(selectionSort);
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            SortingAlgorithm.Quicksort<T>(quickSort, 0, quickSort.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

        }

        
    }
}
