using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Player
    {
        public string Name;

        public Hand Hand { get; private set; }

        public void SetHand(Hand hand)
        {
            Hand = hand;
        }

        public bool HasCards()
        {
            if (Hand == null)
                return false;

            return Hand.HasCards();
        }
    }
}
