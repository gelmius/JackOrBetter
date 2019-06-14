using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jackOrBetter
{
    class Card
    {
        private string face;
        private string suit;
        private int value;

        public Card(string cardFace, string cardSuit, int val)
        {
            face = cardFace;
            suit = cardSuit;
            value = val;
        }

        public string getFace()
        {
            return face;
        }

        public string getSuit()
        {
            return suit;
        }

        public int getValue()
        {
            return value;
        }

        public string getCard()
        {
            return suit + " " + face; 
        }

        public override string ToString() {
            return suit + " " + face;
        }


    }
}
