using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableImplementation
{
    public class KeyValuePair<K, V>
    {
        public KeyValuePair()
        {
        }

        public KeyValuePair(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }

        public K Key
        {
            get;
            private set;
        }

        public V Value
        {
            get;
            set;
        }
    }
}
