using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDisplayer
{
    public class Deck
    {
        public List<Card> CardDeck { get; set; }

        public Deck()
        {
            CardDeck = new List<Card>();
        }

        /// <summary>
        /// Gets the List of all Cards.
        /// </summary>
        /// <returns>List of all Cards.</returns>
        public List<Card> GetAllCards()
        {
            CardDeck.Clear();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value cardValue in Enum.GetValues(typeof(Value)))
                {
                    CardDeck.Add(new Card() { CardSuit = suit, CardValue = cardValue });
                }
            }

            return CardDeck;
        }

        /// <summary>
        /// Draw a card from the Deck.
        /// </summary>
        /// <returns>The Drawn Card.</returns>
        public Card DrawCard()
        {
            var card = CardDeck.FirstOrDefault();
            RemoveCard(card);
            return card;
        }

        /// <summary>
        /// Removes the drawn card from the Deck.
        /// </summary>
        /// <param name="card"></param>
        public void RemoveCard(Card card)
        {
            CardDeck.Remove(card);
            Console.WriteLine($"Removed: {card.CardValue} of {card.CardSuit}");
        }

        /// <summary>
        /// Shuffle the Current Card Deck.
        /// </summary>
        public void ShuffleCardDeck()
        {
            Random rand = new Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < CardDeck.Count; i++)
            {
                int j = rand.Next(i, CardDeck.Count);
                var temp = CardDeck[i];
                CardDeck[i] = CardDeck[j];
                CardDeck[j] = temp;
            }
        }

        /// <summary>
        /// Print the Card Deck.
        /// </summary>
        public void PrintCardDeck()
        {
            for (int i = 0; i < CardDeck.Count; i++)
            {
                Console.WriteLine($"{CardDeck[i].CardValue} of {CardDeck[i].CardSuit}");
            }

            Console.WriteLine($"Count of Cards: {CardDeck.Count}");
        }
    }
}
