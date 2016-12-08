using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary
{
    public interface IDeckManager
    {
        /// <summary>
        /// Deal a set of cards
        /// </summary>
        /// <returns></returns>
        IEnumerable<Card> DealHand(int numberOfCards);

        /// <summary>
        /// Get next card from pile
        /// </summary>
        /// <returns></returns>
        Card? GetNextCard();

        ///// <summary>
        ///// Take back all the cards, and reshuffle cards.
        ///// </summary>
        void ReshuffleDecks();

    }
}
