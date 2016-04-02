using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Player
    {
        public decimal Stack;

        public decimal Bet;

        public bool IsDealer { get; private set; }
        public bool IsSmallBlind { get; private set; }
        public bool IsBigBlind { get; private set; }

        public bool IsMe;

        public Hand Hand { get; private set; }

        public Player(decimal stack, decimal bet, bool isMe = false)
        {
            Stack = stack;
            Bet = bet;
            IsMe = isMe;

            IsDealer = false;
            IsSmallBlind = false;
            IsBigBlind = false;
        }

        public void SetHand(Hand hand)
        {
            Hand = hand;
        }

        public void SetDealer()
        {
            IsDealer = true;
        }

        public void SetSmallBlind()
        {
            IsSmallBlind = true;
        }

        public void SetBigBlind()
        {
            IsBigBlind = true;
        }

        public bool HasCards()
        {
            if (Hand == null)
                return false;

            return Hand.HasTwoCards();
        }
    }
}
