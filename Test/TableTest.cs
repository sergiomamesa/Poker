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

        [Test]
        public void Test_Deck_has_52_Cards()
        {
            Deck Deck = new Deck();
            var numberOfCards = Deck.Cards.Count;

            Assert.AreEqual(numberOfCards, 52);
        }

        [Test]
        public void Test_Game_Starts_Players_Have_Their_Cards()
        {
            Table table = new Table(4);
            table.AddPlayer(new Player() { Name = "Player1" });
            table.AddPlayer(new Player() { Name = "Player2" });
            table.AddPlayer(new Player() { Name = "Player3" });

            table.StartGame();

            bool expected = table.Players[1].Hand.RightCard.Equals(null);

            Assert.AreEqual(expected, false);
        }

    }
}
