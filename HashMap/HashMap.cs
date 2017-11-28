using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    class HashMap<K, V> : IMap<K, V>
    {
        private int size;
        private double loadFactor;
        private int threshold;
        private Entry<K, V>[] table;
        private Entry<K, V> available;
        private const int DEFAULT_CAPACITY = 11;
        private const double DEFAULT_LOADFACTOR = .75;

        /// <summary>
        /// No arg constructor that sets table size and load factor to defaults
        /// </summary>
        public HashMap()
        {
            table = new Entry<K, V>[DEFAULT_CAPACITY];
            loadFactor = DEFAULT_LOADFACTOR;
            threshold = DEFAULT_CAPACITY * (int)DEFAULT_LOADFACTOR;
        }

        /// <summary>
        /// Single arg constructor sets custom capacity for table and uses default load factor
        /// </summary>
        /// <param name="initialCapacity">Custom HashMap size</param>
        public HashMap(int initialCapacity)
        {
            table = new Entry<K, V>[initialCapacity];
            loadFactor = DEFAULT_LOADFACTOR;
            threshold = initialCapacity * (int)DEFAULT_LOADFACTOR;
        }

        /// <summary>
        /// Double argument constructor that takes in custom capacity and load factor 
        /// </summary>
        /// <param name="initialCapacity">Custom HashMap size</param>
        /// <param name="loadFactor">Custom load factor between 0 and 1</param>
        public HashMap(int initialCapacity, double loadFactor)
        {
            table = new Entry<K, V>[initialCapacity];

            if(loadFactor > 0 && loadFactor < 1)
            {
                this.loadFactor = loadFactor;
            }
            else
            {
                throw new ArgumentException("Load factor has to be between 0 and 1.");
            }

            threshold = initialCapacity * (int)loadFactor;
        }

        /// <summary>
        /// Returns the number of entries actually used
        /// </summary>
        /// <returns>The number of entries</returns>
        public int Size()
        {
            return size;
        }

        /// <summary>
        /// Returns false if there are entries or true if there are none
        /// </summary>
        /// <returns>Boolean based on entries</returns>
        public bool IsEmpty()
        {
            return size <= 0;
        }

        /// <summary>
        /// Clears the HashMap and sets size to 0
        /// </summary>
        public void Clear()
        {
            for(int i = 0; i < table.Length; i++)
            {
                table[i] = null;
            }

            size = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            V valueResult = default(V);

            int keyResult = FindMatchingBucket(key);

            if(keyResult >= 0)
            {
                valueResult = table[keyResult].GetValue();
            }

            return valueResult;    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public V Put(K key, V value)
        {
            if(key == null || value == null)
            {
                throw new ArgumentException("Key and Value cannot be null.");
            }

            Entry<K, V> entry = new Entry<K, V>(key, value);
            int hashCode = FindBucket(key);
            table[hashCode] = entry;

            size++;

            return entry.GetValue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Remove(K key)
        {
            V valueResult = default(V);

            int keyResult = FindMatchingBucket(key);

            if(keyResult >= 0)
            {
                valueResult = table[keyResult].GetValue();
                table[keyResult] = null;
            }

            size--;

            return valueResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator Keys()
        {
            List<K> list = new List<K>();

            foreach(Entry<K, V> entry in table)
            {
                list.Add(entry.GetKey());
            }

            return list.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator Values()
        {
            List<V> list = new List<V>();

            foreach (Entry<K, V> entry in table)
            {
                list.Add(entry.GetValue());
            }

            return list.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int FindBucket(K key)
        {
            StringKey stringKey = new StringKey(key.ToString());

            return stringKey.GetHashCode() % table.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int FindMatchingBucket(K key)
        {
            int result = -1;

            for(int i = 0; i < table.Length; i++)
            {
                if (table[i].GetKey().Equals(key))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Rehash()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int Resize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        class Entry<K, V>
        {
            private K key;
            private V value;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public Entry(K key, V value)
            {
                this.key = key;
                this.value = value;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public K GetKey()
            {
                return key;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public V GetValue()
            {
                return value;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            public void SetValue(V value)
            {
                this.value = value;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("Key: {0}, Value: {1}", key, value);
            }
        }
    }
}
