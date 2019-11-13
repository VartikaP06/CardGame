using System;

namespace CardDisplayer
{
    public class Game
    {
        public Deck Deck { get; set; }

        public Game()
        {
            Deck = new Deck();
        }

        public void StartGame()
        {
            Deck.GetAllCards();
            Deck.ShuffleCardDeck();
        }

        /// <summary>
        /// Play the Game.
        /// </summary>
        /// <param name="option">The Option used to Play the Game.</param>
        public void PlayGame(GameOption option)
        {
            if (option == GameOption.P)
            {
                var card = Deck.DrawCard();
                Console.WriteLine($"{card.CardValue} of {card.CardSuit}");
            }
            else if (option == GameOption.S)
            {
                Deck.ShuffleCardDeck();
            }
            else if (option == GameOption.R)
            {
                RestartGame();
            }
        }

        /// <summary>
        /// Restart the Game.
        /// </summary>
        public void RestartGame()
        {
            var cards = Deck.GetAllCards();
            Deck.CardDeck = cards;
            Deck.ShuffleCardDeck();
        }
    }
}
