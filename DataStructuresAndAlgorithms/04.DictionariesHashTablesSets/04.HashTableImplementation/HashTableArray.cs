using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HashImplementation
{
    internal class HashTableArray<K, V>
    {
        public ArrayNode<K, V>[] array;

        public HashTableArray(int capacity)
        {
            array = new ArrayNode<K, V>[capacity];
        }

        public void Add(K key, V value)
        {
            if (key == null || value == null)
            {
                return;
            }

            int index = GetIndex(key);
            if (array[index] == null)
            {
                array[index] = new ArrayNode<K, V>();

            }
            array[index].Add(key, value);
        }

        public V this[K key]
        {
            get
            {
                IEnumerable<KeyValuePair<K, V>> found = this.array[GetIndex(key)].Items;
                foreach (var item in found)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                throw new ArgumentException("Invalid key");
            }
        }

        public void Update(K key, V value)
        {
            int index = GetIndex(key);
            if (array[index] == null)
            {
                throw new ArgumentException("Element does not exist");
            }

            array[index].Update(key, value);

        }

        public bool Remove(K key)
        {
            return array[GetIndex(key)].Remove(key);
        }

        public bool TryGetValue(K key, out V value)
        {
            int index = GetIndex(key);
            if (array[index] == null)
            {
                value = default(V);
                return false;
            }
            return array[index].TryGetValue(key, out value);
        }

        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        public void Clear()
        {
            foreach (var node in array)
            {
                if (node != null)
                {
                    node.Clear();
                }
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                foreach (var node in array)
                {
                    if (node != null)
                    {
                        foreach (var value in node.Values)
                        {
                            yield return value;
                        }
                    }
                }
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                foreach (var node in array)
                {
                    if (node != null)
                    {
                        foreach (var key in node.Keys)
                        {
                            yield return key;
                        }
                    }
                }
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Items
        {
            get
            {
                foreach (var node in array)
                {
                    if (node != null)
                    {
                        foreach (var pair in node.Items)
                        {
                            yield return pair;
                        }
                    }
                }
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Elements
        {
            get
            {
                foreach (var node in array)
                {
                    if (node == null)
                    {
                        continue;
                    }
                    foreach (var entry in node.Items)
                    {
                        if (entry == null)
                        {
                            continue;
                        }
                        yield return entry;
                    }
                }
            }
        }

        private int GetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }
    }
}
