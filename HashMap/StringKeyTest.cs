/**
* StringKeyTest – Test class for StringKey
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
    class StringKeyTest
    {
        const string STUDENT = "Matt Scott 0286401";

        /**
         * Default constructor for test class StringKeyTest
         */
        public StringKeyTest() { }

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
         * Method to test the StringKey constructor
         */
        [Test]
        public void TestConstructor()
        {
            StringKey stringKey = new StringKey("test");

            Assert.That(stringKey, Is.Not.Null);
            Assert.That(stringKey.GetKeyName(), Is.EqualTo("test"));
        }

        /**
         * Method to test GetHashCode() that proper int is returned
         */
            [Test]
            public void TestGetHashCode()
            {
                StringKey stringKey = new StringKey("stop");

                Assert.That(stringKey.GetHashCode(), Is.EqualTo(3446974));
            }

        /**
         * Method to test Equals() returns true when the 2 StringKeys are the same
         */
        [Test]
        public void TestEquals_True()
        {
            StringKey stringKey1 = new StringKey("test");
            StringKey stringKey2 = new StringKey("test");

            Assert.That(stringKey1.Equals(stringKey2), Is.True);
        }

        /**
         * Method to test Equals() returns false when the 2 StringKeys are different
         */
        [Test]
        public void TestEquals_False()
        {
            StringKey stringKey1 = new StringKey("stop");
            StringKey stringKey2 = new StringKey("pots");

            Assert.That(stringKey1.Equals(stringKey2), Is.False);
        }

        /**
         * Method to test GetKeyName() returns proper key name
         */
        [Test]
        public void TestGetKeyName()
        {
            StringKey stringKey1 = new StringKey("test");

            Assert.That(stringKey1.GetKeyName(), Is.EqualTo("test"));
        }

        /**
         * Method to test ToString() returns correct string
         */
        [Test]
        public void TestToString()
        {
            StringKey stringKey1 = new StringKey("test");

            Assert.That(stringKey1.ToString(), Is.EqualTo("test"));
        }

        /**
         * Method to test CompareTo() returns negative number when other is greater
         */
        [Test]
        public void TestCompareTo_Negative_1()
        {
            StringKey stringKey1 = new StringKey("test");
            StringKey stringKey2 = new StringKey("testing");

            Assert.That(stringKey1.CompareTo(stringKey2), Is.EqualTo(-1));
        }

        /**
         * Method to test CompareTo() returns 0 when other is equal
         */
        [Test]
        public void TestCompareTo_Zero()
        {
            StringKey stringKey1 = new StringKey("test");
            StringKey stringKey2 = new StringKey("test");

            Assert.That(stringKey1.CompareTo(stringKey2), Is.EqualTo(0));
        }

        /**
         * Method to test CompareTo() returns 1 when other is less
         */
        [Test]
        public void TestCompareTo_One()
        {
            StringKey stringKey1 = new StringKey("test");
            StringKey stringKey2 = new StringKey("tes");

            Assert.That(stringKey1.CompareTo(stringKey2), Is.EqualTo(1));
        }
    }
}
