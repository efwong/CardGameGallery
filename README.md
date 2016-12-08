# CardGame
I created a generic Card Game class and associated classes in C# for the sigfig assignment.
The generic Card Game provide basic features required in any card game (shuffling, dealing, etc.)

## Project Files

#### Card

* Model to simulate a card
* Contains a suit(Heart, Spades, Clubs, Diamonds) and a rank(2,3,...Ace)

#### DeckManager
* Main logic of the application
* Handles dealing cards and shuffling

#### IDeckManager
* interface for handling cards

#### GenericCardGame
* abstract base class for our generic card game
* other concrete class can inherit and have access to generic properties such as the  players or the deckManager


## Assumptions
I'll assume that the supported card games are based on the standard playing cards using suits(Heart, Spade, Clubs, Diamonds) and the rank (2,3,...,10,Jack,Queen,King,Ace).
I'm also assuming that the GenericCardGame is intended to be inherited by other concrete card game classes.
I made the DeckManager an interface because I assumed that there can be other implementations for managing a deck (eg. different ways of dealing a hand or shuffling)

## Supported Features

* Starting a new game
* Shuffling cards
* Dealing a hand to a player
* Playing a round
* Abstract method for determining a winner


