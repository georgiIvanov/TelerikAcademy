using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AlgorithmPerformance
{
    class SortingAlgorithm
    {
        public static void InsertionSort<T>(T[] array) where T : IComparable<T>
        {
            int arrLen = array.Length;

            for (int i = 1; i < arrLen; i++)
            {
                T value = array[i];
                int j = i - 1;
                bool done = false;
                while (!done)
                {
                    if (array[j].CompareTo(value) > 0)
                    {
                        array[j + 1] = array[j];
                        j--;
                        if (j < 0)
                        {
                            done = true;
                        }
                    }
                    else
                    {
                        done = true;
                    }
                }

                array[j + 1] = value;
            }
        }

        public static void SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            int min, arrLen = array.Length - 1;
            for (int i = 0; i < arrLen; i++)
            {
                min = i;
                for (int j = i + 1; j <= arrLen; j++)
                {
                    if (array[j].CompareTo(array[min]) < 0)
                    {
                        min = j;
                    }
                }

                T temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        public static void Quicksort<T>(T[] array, int left, int right)
            where T: IComparable<T>
        {
            int i = left;
            int j = right;
            int pivot = (left + right) / 2;
            T x = array[pivot];

            while (i <= j)
            {
                while (array[i].CompareTo(x) < 0)
                {
                    i++;
                }
                while (x.CompareTo(array[j]) < 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }

            }

            if (left < j)
            {
                Quicksort(array, left, j);
            }

            if (i < right)
            {
                Quicksort(array, i, right);
            }
        }

    }
}
