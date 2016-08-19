using Poker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card
    {
        public SuitType Suit { get; set; }
        public RankType Rank { get; set; }

        public Card(SuitType suit, RankType rank)
        {
            Suit = suit;
            Rank = rank;
        }

        //public override bool Equals(object obj)
        //{
        //    Card cardToCompare = (Card)obj;
        //    if (cardToCompare.Rank != this.Rank)
        //        return false;

        //    if (cardToCompare.Suit != this.Suit)
        //        return false;

        //    return true;
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
    
}
