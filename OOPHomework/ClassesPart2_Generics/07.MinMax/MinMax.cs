using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericList
{
    class AutoGrow
    {
        static void Main(string[] args)
        {
            //GenericList<string> list = new GenericList<string>(5);
            //list.Add("232.3");
            //list.Add("will be removed");
            //list.Add("2dwad.3");
            //list.Add("2kj231332.3");
            //list.Add("2.3");
            //list.Add("over the initial size");
            //list.Add("over the initial size");
            //list.Add("over the initial size");


            GenericList<double> list = new GenericList<double>(5);
            list.Add(2.5);
            list.Add(5.5);
            list.Add(1023.5);
            list.Add(-23.5);
            list.Add(6.5);
            list.Add(28.5);
            list.Add(288.5);
            list.Add(10);
            list.Add(4);

            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
        }
    }

    class GenericList<T> where T : IComparable
    {
        T[] stuff;
        int lastElemIndex, arraySize;

        public GenericList(int capacity)
        {
            stuff = new T[capacity];
            lastElemIndex = 0;
            arraySize = capacity;
        }
        private void DoubleArraySize()
        {
            arraySize = stuff.Length * 2;
            T[] newArr = new T[arraySize];
            for(int i = 0; i < stuff.Length; i++)
            {
                newArr[i] = stuff[i];
            }
            stuff = newArr;
        }

        public void Add(T thing)
        {
            if (lastElemIndex >= stuff.Length)
            {
                DoubleArraySize();
            }
            stuff[lastElemIndex] = thing;
            lastElemIndex++;
        }

        public T this[int index]
        {
            get
            {
                return stuff[index];
            }
            set
            {
                if (index < 0 || index >= stuff.Length)
                {
                    throw new ArgumentOutOfRangeException("index out of range");
                }
                stuff[index] = value;
            }
        }
        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= stuff.Length)
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }

            T[] newArr = new T[stuff.Length];
            for (int i = 0; i < stuff.Length; i++)
            {
                if (i == index) continue;
                newArr[i] = stuff[i];
            }
            stuff = newArr;
        }
        public void ClearList()
        {
            stuff = new T[stuff.Length];
        }
        public T GetElemByValue(T elem)
        {
            if (elem == null) return default(T);
            int i = 0;
            for (i = 0; i < stuff.Length; i++)
            {
                if (stuff[i] != null && stuff[i].CompareTo(elem) == 0)
                {
                    return stuff[i];
                }
            }
            return default(T);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in stuff)
            {
                if (item != null)
                    sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public T Min()
        {
            T minElem = default(T);
            //find first non-null element
            for (int i = 0; i < stuff.Length; i++)
            {
                if (stuff[i] != null)
                {
                    minElem = stuff[i];
                    break;
                }
            }

            if(minElem.CompareTo(default(T)) == 0)
            {
                throw new ArgumentNullException("No elements in array");
            }

            for (int i = 0; i < stuff.Length; i++)
            {
                if (minElem.CompareTo(stuff[i]) > 0 && i < lastElemIndex)
                {
                    minElem = stuff[i];
                }
            }

            return minElem;
        }

        public T Max()
        {
            T maxElem = default(T);
            //find first non-null element
            for (int i = 0; i < stuff.Length; i++)
            {
                if (stuff[i] != null)
                {
                    maxElem = stuff[i];
                    break;
                }
            }

            if (maxElem.CompareTo(default(T)) == 0)
            {
                throw new ArgumentNullException("No elements in array");
            }

            for (int i = 0; i < stuff.Length; i++)
            {
                if (maxElem.CompareTo(stuff[i]) < 0 && i < lastElemIndex)
                {
                    maxElem = stuff[i];
                }
            }

            return maxElem;
        }
    }
}
