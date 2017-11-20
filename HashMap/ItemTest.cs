/**
* ItemTest – Test class for Item class
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
    using NUnit.Framework;

    [TestFixture]
    class ItemTest
    {
        const string STUDENT = "Matt Scott 0286401";

        /**
         * Default constructor for test class StringKeyTest
         */
        public ItemTest() { }

        /**
         * Sets up the test fixture.
         *
         * Called before every test case method.
         */
        [SetUp]
        public void SetUp() { }

        /**
         * Tears down the test fixture.
         *
         * Called after every test case method.
         */
        [TearDown]
        public void TearDown() { }

        /**
         * Method to test Item constructor
         */
        [Test]
        public void TestItemConstructor()
        {
            Item item = new Item("test", 1, 1);

            Assert.That(item, Is.Not.Null);
            Assert.That(item.GetName(), Is.EqualTo("test"));
            Assert.That(item.GetGoldPieces(), Is.EqualTo(1));
            Assert.That(item.GetWeight(), Is.EqualTo(1));
        }

        /**
         * Method to test GetName() returns the proper name
         */
        [Test]
        public void TestGetName()
        {
            Item item = new Item("test", 1, 1);

            Assert.That(item.GetName(), Is.EqualTo("test"));
        }

        /**
         * Method to test GetGoldPieces() returns the proper int
         */
        [Test]
        public void TestGetGoldPieces()
        {
            Item item = new Item("test", 1, 1);

            Assert.That(item.GetGoldPieces(), Is.EqualTo(1));
        }

        /**
         * Method to test GetWeight() returns the proper double
         */
        [Test]
        public void TestGetWeight()
        {
            Item item = new Item("test", 1, 1);

            Assert.That(item.GetWeight(), Is.EqualTo(1));
        }

        /**
         * Method to test ToString() returns the proper string
         */
        [Test]
        public void TestToString()
        {
            Item item = new Item("test", 1, 1);

            Assert.That(item.ToString(), Is.EqualTo("Name: test, Gold Pieces: 1, Weight: 1"));
        }

        /**
         * Method to test CompareTo() returns negative number when other is greater
         */
        [Test]
        public void TestCompareTo_Negative_1()
        {
            Item item1 = new Item("test1", 1, 1);
            Item item2 = new Item("test2", 2, 2);

            Assert.That(item1.CompareTo(item2), Is.EqualTo(-1));
        }

        /**
         * Method to test CompareTo() returns 0 when other is the same
         */
        [Test]
        public void TestCompareTo_Zero()
        {
            Item item1 = new Item("test1", 1, 1);
            Item item2 = new Item("test2", 1, 1);

            Assert.That(item1.CompareTo(item2), Is.EqualTo(0));
        }

        /**
         * Method to test CompareTo() returns 1 when other is less
         */
        [Test]
        public void TestCompareTo_One()
        {
            Item item1 = new Item("test1", 2, 2);
            Item item2 = new Item("test2", 1, 1);

            Assert.That(item1.CompareTo(item2), Is.EqualTo(1));
        }
    }
}
