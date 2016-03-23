using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Initialise();
            Shuffle();
        }

        private void Initialise()
        {
            foreach (Card.SuitType s in Enum.GetValues(typeof(Card.SuitType)))
            {
                foreach (Card.RankType r in Enum.GetValues(typeof(Card.RankType)))
                {
                    Card Card = new Card(s, r);
                    this.Cards.Add(Card);
                }
            }
        }

        private void Shuffle()
        {
            var rnd = new Random();   
            Cards = (List<Card>)Cards.OrderBy(item => rnd.Next());
        }


    }
}
