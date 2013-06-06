using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashImplementation
{
    internal class ArrayNode<K, V>
    {
        public List<KeyValuePair<K, V>> items;

        public ArrayNode()
        {
            items = new List<KeyValuePair<K, V>>();
        }

        public void Add(K key, V value)
        {
            foreach (var pair in items)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("Such key already exists in collection.");
                }
            }
            items.Add(new KeyValuePair<K, V>(key, value));
        }

        public bool Update(K key, V value)
        {
            bool updated = false;

            foreach (var pair in items)
            {
                if (pair.Key.Equals(key))
                {
                    pair.Value = value;
                    updated = true;
                    break;
                }
            }

            return updated;
        }

        public bool TryGetValue(K key, out V value)
        {
            value = default(V);

            bool found = false;
            if (items != null)
            {
                foreach (var pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        public bool Remove(K key)
        {
            bool removed = false;
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Key.Equals(key))
                    {
                        items.RemoveAt(i);
                        removed = true;
                        break;
                    }
                }
            }

            return removed;
        }

        public void Clear()
        {
            items.Clear();
        }

        public IEnumerable<V> Values
        {
            get
            {
                foreach (var pair in items)
                {
                    yield return pair.Value;
                }
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                if (items != null)
                {
                    foreach (var pair in items)
                    {
                        yield return pair.Key;
                    }
                }
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Items
        {
            get
            {
                foreach (var pair in items)
                {
                    yield return pair;
                }
            }
        }

    }
}
