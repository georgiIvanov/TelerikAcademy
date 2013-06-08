namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        IList<T> array;

        public void Sort(IList<T> collection)
        {
            array = collection;
            QuickSort(0, collection.Count - 1);
        }

        void SwapElements(int index1, int index2)
        {
            T swapValue = array[index1];
            array[index1] = array[index2];
            array[index2] = swapValue;
        }

        void QuickSort(int lVal, int rVal)
        {
            if (rVal - lVal <= 0)
            {
                return;
            }

            int pivotIndex = Partition(lVal, rVal, array[rVal]);

            QuickSort(lVal, pivotIndex - 1);
            QuickSort(pivotIndex + 1, rVal);
        }

        int Partition(int lIndex, int rIndex, T pivot)
        {
            int currentLeft = lIndex;
            int currentRight = rIndex - 1;

            while (true)
            {
                while (array[currentLeft].CompareTo(pivot) < 0)
                {
                    currentLeft++;
                }

                while (currentRight > 0 && array[currentRight].CompareTo(pivot) > 0)
                {
                    currentRight--;
                }

                if (currentLeft >= currentRight)
                {
                    break;
                }

                SwapElements(currentLeft, currentRight);
                
            }

            SwapElements(currentLeft, rIndex);

            return currentLeft;
        }
    }
}
