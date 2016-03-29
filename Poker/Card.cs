using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum SuitType
    {
        Spades = 0,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum RankType
    {
        Two = 0, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }

    public class Card
    {
        public SuitType Suit { get; set; }
        public RankType Rank { get; set; }

        //public Card(int suitIndex, int rankIndex)
        //{
        //    Suit = (SuitType)suitIndex;
        //    Rank = (RankType)rankIndex;
        //}

        public Card(SuitType suit, RankType rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override bool Equals(object obj)
        {
            Card cardToCompare = (Card)obj;
            if (cardToCompare.Rank != this.Rank)
                return false;

            if (cardToCompare.Suit != this.Suit)
                return false;

            return true;
        }
        
    }
    
}
