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
            Assert.Throws<Exception>(() => new Table(maxNumberPlayers, 6));
        }

        [TestCase(9)]
        [TestCase(2)]
        [TestCase(5)]
        public void Test_Max_Number_Players_Equal_Lower_Than_Maximum(int maxNumberPlayers)
        {
            Assert.DoesNotThrow(() => new Table(maxNumberPlayers, 1));
        }

        [TestCase(9,3)]
        [TestCase(6,6)]
        public void Test_Max_Number_Players_Equal_Lower_Than_Maximum(int maxNumberPlayers, int minNumberPlayers)
        {
            Assert.DoesNotThrow(() => new Table(maxNumberPlayers, minNumberPlayers));
        }
    }
}
