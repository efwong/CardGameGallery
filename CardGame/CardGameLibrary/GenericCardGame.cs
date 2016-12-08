using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Abstract generic class to implement a card game
 */
namespace CardGameLibrary
{
    public abstract class GenericCardGame
    {
        protected IDeckManager _deckManager;

        public List<Player> Players { get; set; }

        // determines number of cards in a hand
        public int SizeOfHand { get; set; }

        public GenericCardGame(IDeckManager deckManager, List<Player> players, int sizeOfHand)
        {
            _deckManager = deckManager;
            Players = players;
            SizeOfHand = sizeOfHand;
            RestartGame();
        }

        // Get next set of cards
        public IEnumerable<Card> GetNextHand()
        {
            return _deckManager.DealHand(SizeOfHand);
        }

        // Restart the game with a new deck of cards
        public void RestartGame()
        {
            _deckManager.ReshuffleDecks();
            foreach(var player in Players){
                player.hand = null;
            }
        }


        /// <summary>
        /// Get a list of winners
        /// </summary>
        /// <returns>
        /// a list of players or an empty list if there are no winners (eg. game is not over yet or if the game does not allow for winners)
        /// </returns>
        public abstract List<Player> GetWinners();

        /// <summary>
        /// Get a list of losers
        /// </summary>
        /// <returns> 
        /// a list of players or an empty list if there are no losers (eg. game is not over yet or if the game does not allow for losers)
        /// </returns>
        public abstract List<Player> GetLosers();

        /// <summary>
        /// Execute one round of the card game
        /// </summary>
        public abstract void PlayOneRound();
    }
}
