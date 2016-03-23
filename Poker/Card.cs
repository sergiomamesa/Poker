using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card
    {
        private SuitType Suit { get; set; }
        private RankType Rank { get; set; }

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

        public Card(SuitType suit, RankType rank)
        {
            Suit = suit;
            Rank = rank;
        }
        
    }
    
}
