namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var entries in items)
            {
                if (entries.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int lowerBound = 0;
            int upperBound = items.Count - 1;
            int current = 0;
            bool found = false;

            while (true)
            {
                current = (lowerBound + upperBound) >> 1;

                if (lowerBound > upperBound)
                {
                    break;
                }
                else if (items[current].CompareTo(item) == 0)
                {
                    found = true;
                    break;
                }
                else
                {
                    if (items[current].CompareTo(item) > 0)
                    {
                        lowerBound = current + 1;
                    }
                    else
                    {
                        upperBound = current - 1;
                    }
                }
            }

            return found;
        }

        /// <summary>
        /// Shuffles array with O(n) complexity
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();

            for (int i = items.Count - 1; i >= 0 ; i--)
            {
                int randomNumber = rng.Next(0, i + 1);
                T temp = items[randomNumber];
                items[randomNumber] = items[i];
                items[i] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
