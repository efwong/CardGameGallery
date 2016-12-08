using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary
{
    /// <summary>
    /// Simple struct implementation for Card containing a rank and a suit
    /// I decided to use a struct because I would need to generate multiple cards, and using a value type is benefitial for creating deep copies.
    /// </summary>
    public struct Card
    {
        public Rank rank;
        public Suit suit;

        public Card(Rank cardRank, Suit cardSuit)
        {
            rank = cardRank;
            suit = cardSuit;
        }
    }
}
