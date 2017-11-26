/**
* Item – Constructor for Item as well as getters. Item inherits from IComparable
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
    class Item : IComparable<Item>
    {
        const string STUDENT = "Matt Scott 0286401";

        private string name;
        private int goldPieces;
        private double weight;

        /// <summary>
        /// Constructor for the Item which includes the name, value in gold pieces and weight
        /// </summary>
        /// <param name="name">The name of the item</param>
        /// <param name="goldPieces">The value in gold pieces</param>
        /// <param name="weight">The weight of the item</param>
        public Item(string name, int goldPieces, double weight)
        {
            this.name = name;
            this.goldPieces = goldPieces;
            this.weight = weight;
        }

        /// <summary>
        /// Returns a string of the item name
        /// </summary>
        /// <returns>The name of the item</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Returns an int of the value of the item in gold pieces
        /// </summary>
        /// <returns>The int value in gold pieces</returns>
        public int GetGoldPieces()
        {
            return goldPieces;
        }

        /// <summary>
        /// Returns a double of the item weight
        /// </summary>
        /// <returns>The weight of the item</returns>
        public double GetWeight()
        {
            return weight;
        }

        /// <summary>
        /// Returns a string of the item
        /// </summary>
        /// <returns>The item in string format</returns>
        public override string ToString()
        {
            return string.Format("Name: {0}, Gold Pieces: {1}, Weight: {2}", name, goldPieces, weight);
        }

        /// <summary>
        /// Returns an int based on a comparison between this Item and another
        /// </summary>
        /// <param name="other">The Item to be compared to<</param>
        /// <returns>-1 if other is greater, 0 if equal, 1 if this is greater</returns>
        public int CompareTo(Item other)
        {
            return name.CompareTo(other.GetName());
        }
    }
}
