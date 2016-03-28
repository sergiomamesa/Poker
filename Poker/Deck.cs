using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Deck
    {
        private List<Card> Cards { get; set; }

        public int RemainingCards { get { return Cards.Count; } }

        public Deck()
        {
            Initialise();
            Shuffle();
        }

        private void Initialise()
        {
            Cards = new List<Card>();
            foreach (Card.SuitType s in Enum.GetValues(typeof(Card.SuitType)))
            {
                foreach (Card.RankType r in Enum.GetValues(typeof(Card.RankType)))
                {
                    Card Card = new Card(s, r);
                    Cards.Add(Card);
                }
            }
        }

        private void Shuffle()
        {
            var rnd = new Random();
            //            Cards = (List<Card>)Cards.OrderBy(item => rnd.Next());
            Cards = Cards.OrderBy(item => rnd.Next()).ToList();
        }

        private Card GiveCard()
        {
            Card card = this.Cards.First();
            this.Cards.RemoveAt(0);

            return card;
        }

        public Hand GiveHand()
        {
            Hand hand = new Hand()
            {
                LeftCard = GiveCard(),
                RightCard = GiveCard()
            };

            return hand;
        }
    }
}
