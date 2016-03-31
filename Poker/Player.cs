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

        public bool IsMe;

        public Hand Hand { get; private set; }

        public Player(decimal stack, decimal bet, bool isMe = false)
        {
            Stack = Stack;
            Bet = Bet;
            IsMe = isMe;

            IsDealer = false;
        }

        public void SetHand(Hand hand)
        {
            Hand = hand;
        }

        public void SetDealer(bool value)
        {
            IsDealer = value;
        }

        public bool HasCards()
        {
            if (Hand == null)
                return false;

            return Hand.HasTwoCards();
        }
    }
}
