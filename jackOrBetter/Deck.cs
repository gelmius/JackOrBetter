using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jackOrBetter
{
    class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int NUMBER_OF_CARDS = 52;
        private Random ranNum;

        public Deck()
        {
            string[] faces = {"Two", "Three", "Four", "Five", "Six", "Seven",
                                "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            deck = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            ranNum = new Random();
            for(int i = 0; i < deck.Length; i++)
            {
                deck[i] = new Card(faces[i % 13], suits[i / 13], (i%13)+2);
            }
        }

        public void Shuffle()
        {
            currentCard = 0;
            for(int i = 0; i < deck.Length; i++)
            {
                int second = ranNum.Next(NUMBER_OF_CARDS);
                Card temp = deck[i];
                deck[i] = deck[second];
                deck[second] = temp;
            }
        }
        public Card DealCard()
        {
            if (currentCard < deck.Length)
                return deck[currentCard++];
            else
                return null;
        }

    }
}
