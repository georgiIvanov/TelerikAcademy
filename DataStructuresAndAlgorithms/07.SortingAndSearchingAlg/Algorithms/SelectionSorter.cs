namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            T swapValue;
            int min = 0;
            int length = collection.Count;

            for (int k = 0; k < length - 1; k++)
            {
                min = k;
                for (int i = k + 1; i < length; i++)
                {
                    if (collection[i].CompareTo(collection[min]) < 0)
                    {
                        min = i;
                    }
                }

                if (collection[k].CompareTo(collection[min]) > 0)
                {
                    swapValue = collection[k];
                    collection[k] = collection[min];
                    collection[min] = swapValue;
                }
            }
        }
    }
}
