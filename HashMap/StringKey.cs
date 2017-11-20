using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    class StringKey : IComparable<StringKey>
    {
        private string keyName;
        private static double COEFFICIENT = 31;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyName"></param>
        public StringKey(string keyName)
        {
            this.keyName = keyName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(object o)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetKeyName()
        {
            return keyName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(StringKey other)
        {
            throw new NotImplementedException();
        }
    }
}
