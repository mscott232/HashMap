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
        /// 
        /// </summary>
        public HashMap() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialCapacity"></param>
        public HashMap(int initialCapacity)
        {
            threshold = initialCapacity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialCapacity"></param>
        /// <param name="loadFactor"></param>
        public HashMap(int initialCapacity, double loadFactor)
        {
            threshold = initialCapacity;
            this.loadFactor = loadFactor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public V Put(K key, V value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Remove(K key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator Keys()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator Values()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int FindBucket(K key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int FindMatchingBucket()
        {
            throw new NotImplementedException();
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
