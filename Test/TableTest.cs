using NUnit.Framework;
using Poker;
using System;

namespace Test
{
    [TestFixture]
    public class TableTest
    {
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(15)]
        public void Test_Max_Number_Players_Lower_Than_Maximum(int maxNumberPlayers)
        {
            var exception = Assert.Throws<Exception>(() => new Table(maxNumberPlayers));
            Assert.AreEqual(exception.Message, "MaxNumberPlayers cannont exceed 9");
        }

        [TestCase(9)]
        [TestCase(2)]
        [TestCase(5)]
        public void Test_Max_Number_Players_Equal_Lower_Than_Maximum(int maxNumberPlayers)
        {
            Assert.DoesNotThrow(() => new Table(maxNumberPlayers));
        }

        [TestCase(1)]
        public void Test_Min_Number_Players_Greater_Than_Maximum(int maxNumberPlayers)
        {
            var exception = Assert.Throws<Exception>(() => new Table(maxNumberPlayers));
            Assert.AreEqual(exception.Message, "MIN_NUMBER_PLAYERS cannot be greater than MaxNumberPlayers");
        }
    }
}
