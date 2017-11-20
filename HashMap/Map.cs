/**
* Map – Interface for map methods
*
* <pre>
*
* Assignment: #4
* Course: ADEV-3001
* Date Created: November 20, 2017
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
    interface IMap<K, V>
    {
        /// <summary>
        /// Return how many entries are actually used
        /// </summary>
        /// <returns>Int value of entries</returns>
        int Size();

        /// <summary>
        /// Returns true if there are entries false if there are none
        /// </summary>
        /// <returns>Bool based on entries</returns>
        bool IsEmpty();

        /// <summary>
        /// Sets all entries to null and size to 0
        /// </summary>
        void Clear();

        /// <summary>
        /// Retrieve the value with the key associated
        /// </summary>
        /// <param name="key">The key used to find the entry</param>
        /// <returns>Returns null if there if the key is not in the map</returns>
        V Get(K key);

        /// <summary>
        /// Adds or replaces an entry
        /// </summary>
        /// <param name="key">The key of the entry</param>
        /// <param name="value">The value of the entry</param>
        V Put(K key, V value);

        /// <summary>
        /// Removes the value from the map
        /// </summary>
        /// <param name="key">The key used to find the entry</param>
        /// <returns>Returns null if there if the key is not in the map</returns>
        V Remove(K key);

        /// <summary>
        /// Returns an IEnumerable of all the keys in the map
        /// </summary>
        /// <returns>An IEnumerable of all keys</returns>
        IEnumerable Keys();

        /// <summary>
        /// Returns an IEnumerable of all the values in the map
        /// </summary>
        /// <returns>An IEnumerable of all values</returns>
        IEnumerable Values();
    }
}
