using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jackOrBetter
{

    
    static class Score
    {
        public enum VALUE
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        public static void score(Card[] cards)
        {
            Card[] table;
            table = cards;
            sordCards(table);
            Console.WriteLine();
            if(isRoyalFlush(table))
                Console.WriteLine("Royal Flush! win: 800");
            else if (isStraighFlush(table))
                Console.WriteLine("Straigh Flush! win: 50");
            else if (isFourOfKind(table))
                Console.WriteLine("Four Of A Kind! win: 25");
            else if (isFullHouse(table))
                Console.WriteLine("Full House! win: 9");
            else if (isFlush(table))
                Console.WriteLine("Flush! win: 6");
            else if (isStraigh(table))
                Console.WriteLine("Straigh! win: 4");
            else if (isThreeOfKind(table))
                Console.WriteLine("Three Of A Kind! win: 3");
            else if (isTwoPair(table))
                Console.WriteLine("Two Pair! win: 2");
            else if (isJackOrBetter(table))
                Console.WriteLine("Jack Or Better! win: 1");
            else
                Console.WriteLine("try another time win: 0");
        }

        private static bool isJackOrBetter(Card[] table)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (table[i].getFace() == table[j].getFace() && table[i].getValue()>10)
                    {
                            return true;
                    }
                }
            }
            return false;
        }

        private static void sordCards(Card[] table)
        {
            for (int j = 0; j <= table.Length - 2; j++)
            {
                for (int i = 0; i <= table.Length - 2; i++)
                {
                    if (table[i].getValue() > table[i + 1].getValue())
                    {
                        Card temp = table[i + 1];
                        table[i + 1] = table[i];
                        table[i] = temp;
                    }
                }
            }
        }

        private static bool isTwoPair(Card[] table)
        {
            //if 1,2 and 3,4
            //if 1.2 and 4,5
            //if 2.3 and 4,5
            //with two pairs, the 2nd card will always be a part of one pair 
            //and 4th card will always be a part of second pair
            if (table[0].getValue() == table[1].getValue() && table[2].getValue() == table[3].getValue())
            {
                return true;
            }
            else if (table[0].getValue() == table[1].getValue() && table[3].getValue() == table[4].getValue())
            {
                return true;
            }
            else if (table[1].getValue() == table[2].getValue() && table[3].getValue() == table[4].getValue())
            {
                return true;
            }
            return false;
        }

        private static bool isThreeOfKind(Card[] table)
        {
            if ((table[0].getValue() == table[1].getValue() && table[0].getValue() == table[2].getValue()) ||
            (table[1].getValue() == table[2].getValue() && table[1].getValue() == table[3].getValue()))
            {
                return true;
            }
            else if (table[2].getValue() == table[3].getValue() && table[2].getValue() == table[4].getValue())
            {
                return true;
            }
            return false;
        }

        public static bool isStraigh(Card[] table)
        {
            if(table[4].getFace() == "Ace")
            {
                if (table[0].getValue() + 1 == table[1].getValue() &&
                table[1].getValue() + 1 == table[2].getValue() &&
                table[2].getValue() + 1 == table[3].getValue() &&
                table[3].getValue() + 1 == table[4].getValue())
                {
                    return true;
                } else if (1 + 1 == table[0].getValue() &&
                table[0].getValue() + 1 == table[1].getValue() &&
                table[1].getValue() + 1 == table[2].getValue() &&
                table[2].getValue() + 1 == table[3].getValue())
                {
                    return true;
                }
            }

            if (table[0].getValue() + 1 == table[1].getValue() &&
                table[1].getValue() + 1 == table[2].getValue() &&
                table[2].getValue() + 1 == table[3].getValue() &&
                table[3].getValue() + 1 == table[4].getValue())
            {
                return true;
            }
            return false;
        }

        public static bool isFlush(Card[] table)
        {
            int suits = 1;
            for (int i = 1; i < 5; i++)
            {
                if (table[0].getSuit() == table[i].getSuit())
                    suits++;
            }
            if (suits == 5)
                return true;
            else
                return false;
        }
        private static bool isFullHouse(Card[] table)
        {
            if ((table[0].getValue() == table[1].getValue() && table[0].getValue() == table[2].getValue() && table[3].getValue() == table[4].getValue()) ||
                (table[0].getValue() == table[1].getValue() && table[2].getValue() == table[3].getValue() && table[2].getValue() == table[4].getValue()))
            {
                return true;
            }

            return false;
        }

        public static bool isFourOfKind(Card[] table)
        {
            if ((table[0].getValue() == table[1].getValue() && table[0].getValue() == table[2].getValue() && table[0].getValue() == table[3].getValue()) ||
                (table[1].getValue() == table[2].getValue() && table[1].getValue() == table[3].getValue() && table[1].getValue() == table[4].getValue()))
            {
                return true;
            }
            return false;
        }

        public static bool isStraighFlush(Card[] table)
        {

            return isStraigh(table) && isFlush(table);
        }

        public static bool isRoyalFlush(Card[] table)
        {
                if (table[4].getFace() == "Ace")
                {
                    return isStraigh(table) && isFlush(table);
                }
            return false;
        }
    }
}
