using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum PokerHands
    {
        Pair = 0,
        TwoPair,
        ThreeOfKind,
        Straight,
        Flush,
        FullHouse,
        FourOfKind,
        StraightFlush,
        RoyalFlush
    }
    public class Dealer
    {
        private List<Card> PlayingCards { get; set; }

        public void SetCardsToCompare(Board board, Hand playerHand)
        {
            PlayingCards = new List<Card>();
            PlayingCards.Add(board.FirstCard);
            PlayingCards.Add(board.SecondCard);
            PlayingCards.Add(board.ThirdCard);
            PlayingCards.Add(board.FourthCard);
            PlayingCards.Add(board.FifthCard);
            PlayingCards.Add(playerHand.LeftCard);
            PlayingCards.Add(playerHand.RightCard);
        }

        private bool HasPair()
        {
            bool hasPair = PlayingCards.GroupBy(c => c.Rank).Count(g => g.Count() == 2) == 1;
            return hasPair;
        }

        private bool IsPair()
        {
            bool isPair = PlayingCards.GroupBy(card => card.Rank).Count(group => group.Count() == 3) == 0 && HasPair();
            return isPair;
        }

        private bool IsTwoPair()
        {
            bool isPair = PlayingCards.GroupBy(card => card.Rank).Count(group => group.Count() >= 2) == 2;
            return isPair;
        }

        private bool HasThreeOfKind()
        {
            bool hasThreeOfKind = PlayingCards.GroupBy(c => c.Rank).Any(g => g.Count() == 3);
            return hasThreeOfKind;
        }

        private bool isThreeOfKind()
        {
            bool isThreeOfKind = HasThreeOfKind() && !HasPair();
            return isThreeOfKind;
        }

        private bool IsStraight()
        {
            //bool isStraight = PlayingCards.GroupBy(c => c.Rank).Count() == PlayingCards.Count() && 
            //Problem : I'm gonna have 7 cards to evaluate but only 5 play in this
            throw new NotImplementedException();
        }

        private bool IsFlush()
        {
            bool isFlush = PlayingCards.GroupBy(c => c.Suit).Any(g => g.Count() >= 5);
            return isFlush;
        }

        private bool IsPoker()
        {
            bool isPoker = PlayingCards.GroupBy(c => c.Rank).Any(g => g.Count() == 4);
            return isPoker;
        }

        private bool IsFullHouse()
        {
            bool isFullHouse = HasThreeOfKind() && HasPair();
            return isFullHouse;
        }

        private bool HasStraightFlush()
        {
            bool hasStraightFlush = IsFlush() && IsFullHouse();
            return hasStraightFlush;
        }

        private bool IsStarightFlush()
        {
            bool isStraightFlush = HasStraightFlush() && !IsRoyalFlush();
            return isStraightFlush;
        }

        private bool IsRoyalFlush()
        {
            //Same Problem
            throw new NotImplementedException();
        }


    }
}
