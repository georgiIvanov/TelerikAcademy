using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashTableImplementation;

namespace _05.SetImplementation
{
    class HashSet<T>
    {
        HashTable<string, T> hashTable;

        public HashSet()
        {
            hashTable = new HashTable<string, T>();

        }

        public void Add(T value)
        {
            hashTable.Add(value.ToString(), value);
        }

        public T Find(T value)
        {
            return hashTable.Find(value.ToString());
        }

        public bool Remove(T value)
        {
            return hashTable.Remove(value.ToString());
        }

        public int Count
        {
            get
            {
                return hashTable.Count;
            }
        }

        public void Clear()
        {
            hashTable.Clear();
        }

        public IEnumerable<T> Items
        {
            get
            {
                return hashTable.Values;
            }
        }

        public T this[T index]
        {
            get
            {
                return hashTable[index.ToString()];
            }
            set
            {
                hashTable[index.ToString()] = value;
            }
        }

    }
}
