using NUnit.Framework;
using Poker;
using System;
using System.Linq;

namespace Test
{
    [TestFixture]
    public class TableTest
    {
        [TestCase(10)]
        [TestCase(11)]
        public void Test_Max_Number_Players_Lower_Than_Maximum(int maxNumberPlayers)
        {
            var exception = Assert.Throws<Exception>(() => new Table(maxNumberPlayers,0));
            Assert.AreEqual(exception.Message, "MaxNumberPlayers cannont exceed 9");
        }

        [TestCase(9)]
        [TestCase(2)]
        [TestCase(5)]
        public void Test_Max_Number_Players_Equal_Lower_Than_Maximum(int maxNumberPlayers)
        {
            Assert.DoesNotThrow(() => new Table(maxNumberPlayers,0));
        }

        [TestCase(1)]
        public void Test_Min_Number_Players_Greater_Than_Maximum(int maxNumberPlayers)
        {
            var exception = Assert.Throws<Exception>(() => new Table(maxNumberPlayers,0));
            Assert.AreEqual(exception.Message, "MIN_NUMBER_PLAYERS cannot be greater than MaxNumberPlayers");
        }

        [Test]
        public void Test_Deck_has_52_Cards()
        {
            Deck Deck = new Deck();
            int numberOfCards = Deck.RemainingCards;

            Assert.AreEqual(numberOfCards, 52);
        }

        [Test]
        public void Test_Game_Starts_Players_Have_Their_Cards()
        {
            Table table = new Table(4,0);
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));
            table.AddPlayer(new Player(500,0));

            table.StartGame();

            bool expected = table.Players.ToList()[1].HasCards();

            Assert.AreEqual(expected, true);
        }

    }
}
