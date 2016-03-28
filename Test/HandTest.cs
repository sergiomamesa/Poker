using NUnit.Framework;
using Poker;
using System;
using System.Linq;

namespace Test
{
    [TestFixture]
    class HandTest
    {
        [Test]
        public void Hand_Cards_Are_Paired()
        {
            Table table = new Table(3);
            table.AddPlayer(new Player() { Name = "Player1" });

            table.StartGame();

            Player player = table.Players.ToList()[0];
            player.Hand.LeftCard = new Card(1, 2);
            player.Hand.RightCard = new Card(2, 2);

            bool expected = player.Hand.IsPaired();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Hand_Cards_Are_Suited()
        {
            Table table = new Table(3);
            table.AddPlayer(new Player() { Name = "Player1" });

            table.StartGame();

            Player player = table.Players.ToList()[0];
            player.Hand.LeftCard = new Card(1, 2);
            player.Hand.RightCard = new Card(1, 1);

            bool expected = player.Hand.IsSuited();

            Assert.AreEqual(expected, true);
        }

        [Test]
        public void Hand_Cards_Are_Connected()
        {
            Table table = new Table(3);
            table.AddPlayer(new Player() { Name = "Player1" });

            table.StartGame();

            Player player = table.Players.ToList()[0];
            player.Hand.LeftCard = new Card(1, 0);
            player.Hand.RightCard = new Card(2, 12);

            bool expected = player.Hand.IsConnected();

            Assert.AreEqual(expected, true);
        }
    }
}
