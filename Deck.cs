using System;
using System.Collections.Generic;
using System.Text;

namespace Taller_practico_2
{
    public class Deck
    {
        public int costPoints { get; set; }
        public List<Card> cards { get; set; }

        public Deck(int costPoints, List<Card> cards)
        {
            this.costPoints = costPoints;
            this.cards = cards;
        }

        public bool cleanCards()
        {
            cards = new List<Card>();
            return true;
        }

        public void info()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.name);
            }
        }

    }
}