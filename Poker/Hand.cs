using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Hand
    {
        public Card LeftCard { get; set; }
        public Card RightCard { get; set; }

        public bool IsPaired()
        {
            if (LeftCard.Rank == RightCard.Rank)
                return true;

            return false;
        }

        public bool IsSuited()
        {
            if (LeftCard.Suit == RightCard.Suit)
                return true;

            return false;
        }

        public bool IsConnected()
        {
            if (LeftCard.Rank.GetHashCode() == RightCard.Rank.GetHashCode() + 1)
                return true;

            if (RightCard.Rank.GetHashCode() == LeftCard.Rank.GetHashCode() + 1)
                return true;

            if (LeftCard.Rank.GetHashCode() == 0 && RightCard.Rank.GetHashCode() == 12)
                return true;

            if (RightCard.Rank.GetHashCode() == 0 && LeftCard.Rank.GetHashCode() == 12)
                return true;

            return false;
        }

        public bool HasCards()
        {
            if (LeftCard == null)
                return false;

            if (RightCard == null)
                return false;

            return true;
        }
    }
}
