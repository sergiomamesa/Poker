using System;
using NUnit.Framework;
using Poker;

namespace Test
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Player_Has_No_Hand()
        {
            Player player = new Player() { Name = "Player1" };

            bool expected = player.HasCards();

            Assert.AreEqual(expected, false);
        }
    }
}
