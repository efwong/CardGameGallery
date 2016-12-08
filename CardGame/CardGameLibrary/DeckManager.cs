using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * DeckManager
 * Handles methods related to shuffling and dealing cards
 * Main logic of the application
 */
namespace CardGameLibrary
{
    public class DeckManager: IDeckManager
    {
        /// <summary>
        /// Number of decks used
        /// 1 Deck = standard 52 cards
        /// </summary>
        public int NumberOfDecks { get; set; }

        /// <summary>
        /// Pointer to current position in deck
        /// </summary>
        private int CurrentPos { get; set; }

        public IEnumerable<Card> AvailableCards { get; set; }

        public DeckManager(int numberOfDecks)
        {
            NumberOfDecks = numberOfDecks;
            ReshuffleDecks();
            CurrentPos = 0;
        }


        /// <summary>
        /// Get next hand
        /// </summary>
        /// <param name="numberOfCards"></param>
        /// <returns></returns>
        public IEnumerable<Card> DealHand(int numberOfCards)
        {
            // get elements from currentPost to currentPos + numberOfCards (ie. take the next #numberOfCards cards)
            var result = AvailableCards.Skip(CurrentPos).Take(numberOfCards);
            CurrentPos += numberOfCards;
            return result;
        }

        /// <summary>
        /// Get next card. If currentPos is outside range, return null;
        /// </summary>
        /// <returns></returns>
        public Card? GetNextCard()
        {
            if (CurrentPos < 0 || CurrentPos >= AvailableCards.Count())
            {
                return null;
            }

            return AvailableCards.ElementAt(CurrentPos++);
        }

        /// <summary>
        /// Get new deck and reshuffle.
        /// </summary>
        public void ReshuffleDecks()
        {
            AvailableCards = Enumerable.Empty<Card>();
            AvailableCards = GenerateCardsByNumberOfDecks();
            AvailableCards = AvailableCards.Shuffle();
            // reset current pointer
            CurrentPos = 0;
        }

        /// <summary>
        /// Generate #NumberOfDecks decks
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Card> GenerateCardsByNumberOfDecks()
        {
            var deck = GenerateOneDeck();
            if (NumberOfDecks < 1)
            {
                // no decks
                return Enumerable.Empty<Card>();
            }
            else if (NumberOfDecks > 1)
            {
                var oneDeck = deck.ToList(); 
                // create duplicates for
                for (int i = 0; i < NumberOfDecks - 1; i++)
                {
                    deck = deck.Concat(oneDeck);
                }
            }

            return deck;
        }

        /// <summary>
        /// Generate a standard 52 card deck
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Card> GenerateOneDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(rank, suit));
                }
            }
            return deck;
        }
    }
}
