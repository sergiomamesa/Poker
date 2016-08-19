using NUnit.Framework;
using Poker;
using Poker.Enums;
using System;
using System.Linq;

namespace Test
{
    [TestFixture]
    class HandTest
    {

        //[TestCase(SuitType.Clubs, RankType.Ace, SuitType.Clubs, RankType.Ace)]
        //[TestCase(SuitType.Spades, RankType.Eight, SuitType.Spades, RankType.Eight)]
        //public void Test_Cards_Are_Duplicated(SuitType leftCardSuit, RankType leftCardRank,SuitType rightCardSuit, RankType rightCardRank)
        //{
        //    Card leftCard = new Card(leftCardSuit, leftCardRank);
        //    Card rightCard = new Card(rightCardSuit, rightCardRank);

        //    Exception exception = Assert.Throws<Exception>(() => new Hand(leftCard, rightCard));
        //    Assert.AreEqual(exception.Message, "Duplicated card!");
        //}

        [TestCase(SuitType.Clubs, RankType.Ace, SuitType.Diamonds, RankType.Ace)]
        [TestCase(SuitType.Spades, RankType.Eight, SuitType.Hearts, RankType.Eight)]
        public void Test_IsPaired_HandPaired_IsTrue(SuitType leftCardSuit, RankType leftCardRank,SuitType rightCardSuit, RankType rightCardRank)
        {
            Card leftCard = new Card(leftCardSuit, leftCardRank);
            Card rightCard = new Card(rightCardSuit, rightCardRank);
            Hand hand = new Hand(leftCard, rightCard);

            bool expected = hand.IsPaired();

            Assert.AreEqual(expected, true);
        }

        [TestCase(SuitType.Clubs, RankType.Ace, SuitType.Diamonds, RankType.King)]
        [TestCase(SuitType.Spades, RankType.Four, SuitType.Hearts, RankType.Eight)]
        public void Test_IsPaired_HandNotPaired_IsFalse(SuitType leftCardSuit, RankType leftCardRank, SuitType rightCardSuit, RankType rightCardRank)
        {
            Card leftCard = new Card(leftCardSuit, leftCardRank);
            Card rightCard = new Card(rightCardSuit, rightCardRank);
            Hand hand = new Hand(leftCard, rightCard);

            bool expected = hand.IsPaired();

            Assert.AreEqual(expected, false);
        }

        [TestCase(SuitType.Clubs, RankType.Eight, SuitType.Clubs, RankType.Seven)]
        [TestCase(SuitType.Spades, RankType.Eight, SuitType.Spades, RankType.Ace)]
        public void Test_IsSuited_HandSuited_IsTrue(SuitType leftCardSuit, RankType leftCardRank, SuitType rightCardSuit, RankType rightCardRank)
        {
            Card leftCard = new Card(leftCardSuit, leftCardRank);
            Card rightCard = new Card(rightCardSuit, rightCardRank);
            Hand hand = new Hand(leftCard, rightCard);

            bool expected = hand.IsSuited();

            Assert.AreEqual(expected, true);
        }

        [TestCase(SuitType.Spades, RankType.Eight, SuitType.Clubs, RankType.Seven)]
        [TestCase(SuitType.Hearts, RankType.Eight, SuitType.Spades, RankType.Ace)]
        public void Test_IsSuited_HandNotSuited_IsFalse(SuitType leftCardSuit, RankType leftCardRank, SuitType rightCardSuit, RankType rightCardRank)
        {
            Card leftCard = new Card(leftCardSuit, leftCardRank);
            Card rightCard = new Card(rightCardSuit, rightCardRank);
            Hand hand = new Hand(leftCard, rightCard);

            bool expected = hand.IsSuited();

            Assert.AreEqual(expected, false);
        }

        [TestCase(SuitType.Clubs, RankType.Eight,SuitType.Clubs, RankType.Seven)]
        [TestCase(SuitType.Spades, RankType.King,SuitType.Spades, RankType.Ace)]
        [TestCase(SuitType.Spades, RankType.Two,SuitType.Spades, RankType.Ace)]
        [TestCase(SuitType.Spades, RankType.Ace, SuitType.Spades, RankType.Two)]
        public void Test_IsConnected_HandConnected_IsTrue(SuitType leftCardSuit, RankType leftCardRank, SuitType rightCardSuit, RankType rightCardRank)
        {
            Card leftCard = new Card(leftCardSuit, leftCardRank);
            Card rightCard = new Card(rightCardSuit, rightCardRank);
            Hand hand = new Hand(leftCard, rightCard);

            bool expected = hand.IsConnected();

            Assert.AreEqual(expected, true);
        }

        [TestCase(SuitType.Clubs, RankType.Eight, SuitType.Clubs, RankType.Five)]
        [TestCase(SuitType.Spades, RankType.King, SuitType.Spades, RankType.Jack)]
        public void Test_IsConnected_HandNotConnected_IsFalse(SuitType leftCardSuit, RankType leftCardRank, SuitType rightCardSuit, RankType rightCardRank)
        {
            Card leftCard = new Card(leftCardSuit, leftCardRank);
            Card rightCard = new Card(rightCardSuit, rightCardRank);
            Hand hand = new Hand(leftCard, rightCard);

            bool expected = hand.IsConnected();

            Assert.AreEqual(expected, false);
        }

        [Test]
        public void Test_HasTwoCards_NoLeftCard_IsFalse()
        {
            Card rightCard = new Card(SuitType.Clubs, RankType.Ace);
            Hand hand = new Hand(null, rightCard);

            bool expected = hand.HasTwoCards();

            Assert.AreEqual(expected, false);
        }

        [Test]
        public void Test_HasTwoCards_NoRightCard_IsFalse()
        {
            Card leftCard = new Card(SuitType.Clubs, RankType.Ace);
            Hand hand = new Hand(leftCard, null);

            bool expected = hand.HasTwoCards();

            Assert.AreEqual(expected, false);
        }

        [Test]
        public void Test_HasTwoCards_WithTowCards_IsTrue()
        {
            Card leftCard = new Card(SuitType.Clubs, RankType.Ace);
            Card rightCard = new Card(SuitType.Spades, RankType.Ace);
            Hand hand = new Hand(leftCard, rightCard);

            bool expected = hand.HasTwoCards();

            Assert.AreEqual(expected, true);
        }
    }
}
