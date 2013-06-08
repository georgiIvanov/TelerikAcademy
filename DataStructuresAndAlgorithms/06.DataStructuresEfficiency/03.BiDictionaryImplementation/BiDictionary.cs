using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace BiDictionaryImplementation
{
    class BiDictionary<K1, K2, V> 
    {
        MultiDictionary<K1, V> firstKeyDictionary;
        MultiDictionary<K2, V> secondKeyDictionary;
        MultiDictionary<int, V> bothKeysDictionary;
        MultiDictionary<K1, K2> firstSecondKeyDictionary;
        MultiDictionary<K2, K1> secondFirstKeyDictionary;

        public BiDictionary()
        {
            firstKeyDictionary = new MultiDictionary<K1, V>(true);
            secondKeyDictionary = new MultiDictionary<K2, V>(true);
            bothKeysDictionary = new MultiDictionary<int, V>(true);
            firstSecondKeyDictionary = new MultiDictionary<K1, K2>(true);
            secondFirstKeyDictionary = new MultiDictionary<K2, K1>(true);
        }

        
        public void Add(K1 key1, K2 key2, V value)
        {
            int compositeKey = GetCompositeKey(key1, key2);
            bothKeysDictionary.Add(compositeKey, value);
            firstKeyDictionary.Add(key1, value);
            secondKeyDictionary.Add(key2, value);

            firstSecondKeyDictionary.Add(key1, key2);
            secondFirstKeyDictionary.Add(key2, key1);
        }

        public ICollection<V> FindUsingFirstKey(K1 key1)
        {
            List<V> found = new List<V>();

            found.AddRange(firstKeyDictionary[key1]);

            return found;
        }

        public ICollection<V> FindUsingSecondKey(K2 key2)
        {
            List<V> found = new List<V>();

            found.AddRange(secondKeyDictionary[key2]);

            return found;
        }

        public ICollection<V> FindUsingBothKeys(K1 key1, K2 key2)
        {
            List<V> found = new List<V>();

            found.AddRange(firstKeyDictionary[key1]);
            found.AddRange(secondKeyDictionary[key2]);
            found.AddRange(bothKeysDictionary[GetCompositeKey(key1, key2)]);

            return found;
        }

        public void RemoveWithFirstKey(K1 key1)
        {
            if (!firstKeyDictionary.ContainsKey(key1))
            {
                throw new ArgumentException("Invalid key");
            }

            firstKeyDictionary.Remove(key1);
            ICollection<K2> key2 = firstSecondKeyDictionary[key1];
            foreach (var item in key2)
            {
                secondKeyDictionary.Remove(item);
                bothKeysDictionary.Remove(GetCompositeKey(key1, item));
            }
        }

        public void RemoveWithSecondKey(K2 key2)
        {
            if (!secondKeyDictionary.ContainsKey(key2))
            {
                throw new ArgumentException("Invalid key");
            }

            secondKeyDictionary.Remove(key2);
            ICollection<K1> key1 = secondFirstKeyDictionary[key2];
            foreach (var item in key1)
            {
                firstKeyDictionary.Remove(item);
                bothKeysDictionary.Remove(GetCompositeKey(item, key2));
            }
        }

        public void RemoveWithBothKeys(K1 key1, K2 key2)
        {
            if (!firstKeyDictionary.ContainsKey(key1) || !secondKeyDictionary.ContainsKey(key2))
            {
                throw new ArgumentException("Invalid key");
            }

            firstKeyDictionary.Remove(key1);
            secondKeyDictionary.Remove(key2);

            bothKeysDictionary.Remove(GetCompositeKey(key1, key2));

        }

        private int GetCompositeKey(K1 key1, K2 key2)
        {
            int compositeKey = 0;
            unchecked
            {
                compositeKey = key1.GetHashCode() * 5039;
                compositeKey = key2.GetHashCode() * 5039;
            }
            return compositeKey;
        }

    }
}
