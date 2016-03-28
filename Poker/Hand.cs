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
            throw new NotImplementedException();
        }

        public bool IsSuited()
        {
            throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
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
