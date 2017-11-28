/**
* StringKey – Constructor for StringKey and overridden Equals and GetHashCode methods. StringKey inherits from IComparable
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    class StringKey : IComparable<StringKey>
    {
        const string STUDENT = "Matt Scott 0286401";

        private string keyName;
        private static double COEFFICIENT = 31;

        /// <summary>
        /// StringKey constructor
        /// </summary>
        /// <param name="keyName">The keyName for the string key</param>
        public StringKey(string keyName)
        {
            this.keyName = keyName;
        }

        /// <summary>
        /// Returns an int hash code based on the keyname
        /// </summary>
        /// <returns>The int hash code</returns>
        public override int GetHashCode()
        {
            //byte[] asciiBytes = Encoding.ASCII.GetBytes(keyName);
            int result = 0;

            for(int i = 0; i < keyName.Length; i++)
            {
                result += (keyName[i] * (int)Math.Pow(COEFFICIENT, i));
            }

            return Math.Abs(result);
        }

        /// <summary>
        /// Returns true or false based on the comparison of the keyName
        /// </summary>
        /// <param name="o">The object to be compared to</param>
        /// <returns>True or false based on the keyName</returns>
        public override bool Equals(object o)
        {
            if(this == o)
            {
                return true;
            }
            
            if(o == null || GetType() != o.GetType())
            {
                return false;
            }

            StringKey stringKey = (StringKey)o;
            return keyName == stringKey.GetKeyName();
        }

        /// <summary>
        /// Returns the keyName for the StringKey
        /// </summary>
        /// <returns>The keyName</returns>
        public string GetKeyName()
        {
            return keyName;
        }

        /// <summary>
        /// To String version of a StringKey
        /// </summary>
        /// <returns>keyName in a string</returns>
        public override string ToString()
        {
            return string.Format("{0}", keyName);
        }

        /// <summary>
        /// Returns an int based on a comparison between this StringKey and another
        /// </summary>
        /// <param name="other">The StringKey to be compared to</param>
        /// <returns>-1 if other is greater, 0 if equal, 1 if this is greater</returns>
        public int CompareTo(StringKey other)
        {
            return keyName.CompareTo(other.GetKeyName());
        }
    }
}
