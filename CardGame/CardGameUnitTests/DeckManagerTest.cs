using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGameLibrary;
using System.Linq;
using System.Collections.Generic;

namespace CardGameUnitTests
{
    [TestClass]
    public class DeckManagerTest
    {
        private DeckManager deckManager;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    deckManager = new DeckManager(2);
        //}

        [TestMethod]
        public void DeckManager_TestInitialDeck()
        {
            deckManager = new DeckManager(1);

            Assert.AreEqual(1, deckManager.NumberOfDecks, "Incorrect number of decks");
            Assert.AreEqual(52, deckManager.AvailableCards.Count(), "Incorrect number of cards in deck");            
        }

        [TestMethod]
        public void DeckManager_NumberOfCardsInDeck_ShouldMatch()
        {
            deckManager = new DeckManager(1);
            Assert.AreEqual(52, deckManager.AvailableCards.Count(), "Incorrect number of cards in deck");
            
            deckManager = new DeckManager(2);
            Assert.AreEqual(104, deckManager.AvailableCards.Count(), "Incorrect number of cards in deck");
        }

        /// <summary>
        /// Get correct set of cards
        /// </summary>
        [TestMethod]
        public void DeckManager_GetNextCard_ShouldGetCorrectNumberOfCards()
        {
            deckManager = new DeckManager(1);
            int count = 0;
            while(deckManager.GetNextCard() != null){
                count++;
                if (count > 52)
                {
                    break;
                }
            }
            Assert.AreEqual(52, count, "Incorrect number of cards fetched from GetNextCard");
        }


        /// <summary>
        /// Find duplicates from shuffling
        /// </summary>
        [TestMethod]
        public void DeckManager_GetNextCard_ShouldNotGetDuplicatesForOneDeck()
        {
            deckManager = new DeckManager(1);
            Card? originalCard = deckManager.GetNextCard();
            Card? card = null;
            
            while ((card = deckManager.GetNextCard()) != null )
            {
                Assert.IsFalse(card.Value.rank == originalCard.Value.rank && card.Value.suit == originalCard.Value.suit, "Error: Found duplicate card");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            deckManager = null;
        }
    }
}
