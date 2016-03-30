using System;
using NUnit.Framework;
using Poker;

namespace Test
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Test_Player_Has_No_Hand()
        {
            Player player = new Player() { Name = "Player1" };

            bool expected = player.HasCards();

            Assert.AreEqual(expected, false);
        }

        [Test]
        public void Test_Player_Has_Hand()
        {
            Player player = new Player() { Name = "Player1" };
            Deck deck = new Deck();

            player.SetHand(deck.GiveHand());

            bool expected = player.HasCards();

            Assert.AreEqual(expected, true);
        }
    }
}
