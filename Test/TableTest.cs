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
            var exception = Assert.Throws<Exception>(() => new Table(maxNumberPlayers, 0));
            Assert.AreEqual(exception.Message, "MaxNumberPlayers cannont exceed 9");
        }

        [TestCase(9)]
        [TestCase(2)]
        [TestCase(5)]
        public void Test_Max_Number_Players_Equal_Lower_Than_Maximum(int maxNumberPlayers)
        {
            Assert.DoesNotThrow(() => new Table(maxNumberPlayers, 0));
        }

        [TestCase(1)]
        public void Test_Min_Number_Players_Greater_Than_Maximum(int maxNumberPlayers)
        {
            var exception = Assert.Throws<Exception>(() => new Table(maxNumberPlayers, 0));
            Assert.AreEqual(exception.Message, "MIN_NUMBER_PLAYERS cannot be greater than MaxNumberPlayers");
        }

        [Test]
        public void Test_Deck_has_52_Cards()
        {
            Deck Deck = new Deck();
            int numberOfCards = Deck.RemainingCards;

            Assert.AreEqual(numberOfCards, 52);
        }

        [TestCase(2)]
        public void Test_Game_Starts_Players_Have_Their_Cards(int seatNumber)
        {
            Table table = new Table(4, 0);
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));
            table.AddPlayer(new Player(500, 0));

            table.StartGame();

            bool expected = table.Players.ToList()[seatNumber].HasCards();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Test_Set_Dealer_No_Empty_Seat()
        {
            Player playerDealer = new Player(500, 0);

            Table table = new Table(4, 0);
            table.AddPlayer(new Player(500, 0), 1);
            table.AddPlayer(playerDealer, 3);
            table.AddPlayer(new Player(500, 0), 4);

            table.SetDealer(3);

            Assert.IsTrue(playerDealer.IsDealer);
        }

        [Test]
        public void Test_Set_Dealer_Empty_Seat()
        {
            Player playerDealer = new Player(500, 0);

            Table table = new Table(4, 0);
            table.AddPlayer(new Player(500, 0), 1);
            table.AddPlayer(playerDealer, 3);
            table.AddPlayer(new Player(500, 0), 4);

            var exception = Assert.Throws<Exception>(() => table.SetDealer(2));
            Assert.AreEqual(exception.Message, "Sorry, selected seat is empty!");
        }

        [TestCase(1, 3)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        public void Test_Set_BigBlind(int dealer, int bigBlind)
        {
            Player playerBigBlind = new Player(500, 0);

            Table table = new Table(4, 0);
            table.AddPlayer(new Player(500, 0), 1);
            table.AddPlayer(new Player(500, 0), 2);
            table.AddPlayer(playerBigBlind, 3);
            table.AddPlayer(new Player(500, 0), 4);

            table.SetDealer(dealer);

            var expected = table.Seats[bigBlind].Player.IsBigBlind;
            Assert.IsTrue(expected);
        }

        [TestCase(1, 3)]
        [TestCase(3, 4)]
        [TestCase(4, 1)]
        public void Test_Set_SmallBlind(int dealer, int smallBlind)
        {
            Table table = new Table(4, 0);
            table.AddPlayer(new Player(500, 0), 1);
            table.AddPlayer(new Player(500, 0), 3);
            table.AddPlayer(new Player(500, 0), 4);

            table.SetDealer(dealer);

            var expected = table.Seats[smallBlind].Player.IsSmallBlind;
            Assert.IsTrue(expected);
        }

        [TestCase(1,2)]
        [TestCase(10, 23)]
        public void Test_Set_Table_Blinds(int bigBlind, int smallBlind)
        {
            Table table = new Table(8, 0);

            var exception = Assert.Throws<Exception>(() => table.SetBlinds(bigBlind,smallBlind));
            Assert.AreEqual(exception.Message, "Sorry small blind cannot be greater than big blind!");
        }
    }
}
