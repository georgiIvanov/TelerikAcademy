namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        IList<T> array;
        IList<T> mergeArray;

        public void Sort(IList<T> collection)
        {
            array = collection;
            mergeArray = new T[collection.Count];

            MergeSort(0, collection.Count - 1);
        }

        void MergeSort(int lowerBound, int upperBound)
        {
            if (lowerBound == upperBound)
            {
                return;
            }

            int mid = (lowerBound + upperBound) >> 1;

            MergeSort(lowerBound, mid);
            MergeSort(mid + 1, upperBound);

            Merge(lowerBound, mid + 1, upperBound);
        }

        void Merge(int low, int mid, int upper)
        {
            int tempLow = low, tempMid = mid - 1;
            int index = 0;

            while (low <= tempMid && mid <= upper)
            {
                if (array[low].CompareTo(array[mid]) < 0)
                {
                    mergeArray[index++] = array[low++];
                }
                else
                {
                    mergeArray[index++] = array[mid++];
                }
            }

            while (low <= tempMid)
            {
                mergeArray[index++] = array[low++];
            }

            while (mid <= upper)
            {
                mergeArray[index++] = array[mid++];
            }

            for (int i = 0; i < upper - tempLow + 1; i++)
            {
                array[tempLow + i] = mergeArray[i];
            }
        }

        
    }
}
