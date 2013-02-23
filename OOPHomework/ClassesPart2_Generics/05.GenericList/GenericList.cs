using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericList
{
    class GenericListProgram
    {
        static void Main(string[] args)
        {
            GenericList<string> list = new GenericList<string>(5);
            list.Add("232.3");
            list.Add("2.3");
            list.Add("2dwad.3");
            list.Add("2kj231332.3");
            list.Add("2.3");

            Console.WriteLine(list);
            Console.WriteLine();
            
            list.RemoveAtIndex(1);
            Console.WriteLine(list);
            Console.WriteLine();

            Console.WriteLine(list[3]);

            list.ClearList();
            Console.WriteLine(list);
            
        }
    }

    class GenericList<T> where T : IComparable
    {
        T[] stuff;
        int lastElemIndex;

        public GenericList(int capacity)
        {
            stuff = new T[capacity];
            lastElemIndex = 0;
        }

        public void Add(T thing)
        {
            if (lastElemIndex >= stuff.Length) throw new ArgumentOutOfRangeException("too much elements");
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
                if(item != null)
                sb.AppendLine(item.ToString());
            }
            
            return sb.ToString().TrimEnd();
        }

    }
}
