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
            foreach (SuitType suit in Enum.GetValues(typeof(SuitType)))
            {
                foreach (RankType rank in Enum.GetValues(typeof(RankType)))
                {
                    Card Card = new Card(suit, rank);
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

        public Card GiveCard()
        {
            Card card = this.Cards.First();
            this.Cards.RemoveAt(0);

            return card;
        }

        public Card GiveSpecificCard(Card card)
        {
            Cards.Remove(card);

            return card;
        }

        public Hand GiveHand()
        {
            Card leftCard = GiveCard();
            Card rightCard = GiveCard();

            Hand hand = new Hand(leftCard, rightCard);

            return hand;
        }
    }
}
