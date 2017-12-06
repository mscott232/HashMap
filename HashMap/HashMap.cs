/**
* HashMap – Constructor for HashMap as well as supporting methods. Item inherits from IMap. Has inner class entry. 
*
* <pre>
*
* Assignment: #4
* Course: ADEV-3001
* Date Created: November 27, 2017
* 
* Revision Log
* Who        When       Reason
* --------- ---------- ----------------------------------
*
* </pre>
*
* @author Matt Scott
* @version 1.0
*/

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
            threshold = (int)(DEFAULT_CAPACITY * DEFAULT_LOADFACTOR);
        }

        /// <summary>
        /// Single arg constructor sets custom capacity for table and uses default load factor
        /// </summary>
        /// <param name="initialCapacity">Custom HashMap size</param>
        public HashMap(int initialCapacity)
        {
            table = new Entry<K, V>[initialCapacity];
            loadFactor = DEFAULT_LOADFACTOR;
            threshold = (int)(initialCapacity * DEFAULT_LOADFACTOR);
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

            threshold = (int)(initialCapacity * loadFactor);
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
            size = 0;

            for(int i = 0; i < table.Length; i++)
            {
                table[i] = null;
            }
        }

        /// <summary>
        /// Returns the value or null with the specified key at it's index
        /// </summary>
        /// <param name="key">The key of the entry</param>
        /// <returns>The value or null</returns>
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
        /// Put's the specified key and value into the hash map
        /// </summary>
        /// <param name="key">The key to be entered</param>
        /// <param name="value">The value associated with the key</param>
        /// <returns>Null or the value of the removed entry</returns>
        public V Put(K key, V value)
        {
            if(key == null || value == null)
            {
                throw new ArgumentNullException("Key and Value cannot be null.");
            }

            if(size + 1 >= threshold)
            {
                Rehash();
            }

            V removed = Remove(key);

            table[FindBucket(key)] = new Entry<K, V>(key, value);

            size++;

            return removed;
        }

        /// <summary>
        /// Removes an entry from the hash map
        /// </summary>
        /// <param name="key">The key of the item to be removed</param>
        /// <returns>The value of the entry removed</returns>
        public V Remove(K key)
        {
            V valueResult = default(V);

            int keyResult = FindMatchingBucket(key);

            if(keyResult != -1)
            {
                valueResult = table[keyResult].GetValue();
                table[keyResult] = null;

                size--;
            }            

            return valueResult;
        }

        /// <summary>
        /// Returns an ienumerable of all the keys in the table
        /// </summary>
        /// <returns>The IEnumerable</returns>
        public IEnumerable Keys()
        {
            List<K> list = new List<K>();

            for(int i = 0; i < table.Length; i++)
            {
                if(table[i] != null)
                {
                    list.Add(table[i].GetKey());
                }
            }

            return list.AsEnumerable();
        }

        /// <summary>
        /// Returns an IEnumerable of all the values in the table
        /// </summary>
        /// <returns>IEnumerable of values</returns>
        public IEnumerable Values()
        {
            List<V> list = new List<V>();

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    list.Add(table[i].GetValue());
                }
            }

            return list.AsEnumerable();
        }

        /// <summary>
        /// Finds a bucket with the associated key
        /// </summary>
        /// <param name="key">The key to search for</param>
        /// <returns>Int of the index of the bucket</returns>
        private int FindBucket(K key)
        {
            StringKey stringKey = new StringKey(key.ToString());

            return stringKey.GetHashCode() % table.Length;
        }

        /// <summary>
        /// Finds a bucket matching the passed in key
        /// </summary>
        /// <returns>The index of the matching bucket or -1 if not found</returns>
        private int FindMatchingBucket(K key)
        {
            int index = FindBucket(key);

            return table[index] == null ? -1 : index;
        }

        /// <summary>
        /// Rehashes the table when the size gets near the threshold
        /// </summary>
        private void Rehash()
        {
            int newCapacity = Resize();
            size = 0;
            threshold = (int)(newCapacity * loadFactor);

            Entry<K, V>[] tableCopy = table;

            table = new Entry<K, V>[newCapacity];

            for(int i = 0; i < tableCopy.Length; i++)
            {
                if(tableCopy[i] != null)
                {
                    Put(tableCopy[i].GetKey(), tableCopy[i].GetValue());
                }
            }
        }

        /// <summary>
        /// Determines the new size of the table when rehashing
        /// </summary>
        /// <returns>Int of the new table capacity</returns>
        private int Resize()
        {
            int newCapacity = (table.Length * 2) + 1;
            bool isPrime = false;
            int squareRoot;

            while(!isPrime)
            {
                isPrime = true;
                squareRoot = (int)Math.Floor(Math.Sqrt(newCapacity));

                for(int i = 3; i <= squareRoot; i++)
                {
                    if(newCapacity % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if(!isPrime)
                {
                    newCapacity += 2;
                }
            }

            return newCapacity;
        }

        /// <summary>
        /// Inner class of entries
        /// </summary>
        /// <typeparam name="K">Key of the entry</typeparam>
        /// <typeparam name="V">Value of the entry</typeparam>
        class Entry<K, V>
        {
            private K key;
            private V value;

            /// <summary>
            /// Entry constructor
            /// </summary>
            /// <param name="key">Key of the entry</param>
            /// <param name="value">Value of the entry</param>
            public Entry(K key, V value)
            {
                this.key = key;
                this.value = value;
            }

            /// <summary>
            /// Returns the key of the entry
            /// </summary>
            /// <returns>The key of the entry</returns>
            public K GetKey()
            {
                return key;
            }

            /// <summary>
            /// Returns the value of the entry
            /// </summary>
            /// <returns>The value of the entry</returns>
            public V GetValue()
            {
                return value;
            }

            /// <summary>
            /// Set's the value of the entry
            /// </summary>
            /// <param name="value">The new value of an entry</param>
            public void SetValue(V value)
            {
                this.value = value;
            }

            /// <summary>
            /// Overriden ToString() method
            /// </summary>
            /// <returns>Returns string of the entry</returns>
            public override string ToString()
            {
                return string.Format("Key: {0}, Value: {1}", key, value);
            }
        }
    }
}
