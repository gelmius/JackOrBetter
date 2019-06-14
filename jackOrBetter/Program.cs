using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jackOrBetter
{
    class Program
    {
        public static Card[] table = new Card[5];
        public static bool draw;
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            bool[] holds = new bool[5];
            draw=false;
            //Card[] table = new Card[5];
            while (true)
            {
                Console.WriteLine();
                switch (DisplayMenu())
                {
                    case 1:
                        //if (holds.Any(x => x))
                        if(draw)
                        {
                            Draw(deck,holds);
                            showTable(holds);
                            //win
                            Score.score(table);
                            //Score score = new Score(table);
                        }
                        else
                        {
                            newGame(deck, holds);
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        
                        break;
                    case 2:
                        //Console.WriteLine(deck.DealCard());
                        hold(holds);
                        Console.Clear();
                        showTable(holds);
                        break;
                    case 0:
                        return;
                }
            }
            Console.ReadLine();
        }

        public static void Draw(Deck deck, bool[] holds)
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                if(holds[i] == false)
                    table[i] = deck.DealCard();
                else
                    holds[i] = false;
            }
            draw = false;
        }

        

        public static void newGame(Deck deck,bool[] holds) {
            Console.Clear();
            deck.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                holds[i] = false;
                table[i] = deck.DealCard();
                Console.WriteLine((i+1) + ". "+ table[i].getCard());
                
            }
            draw = true;

        }

        public static void hold(bool[] holds)
        {
            
            Console.WriteLine("witch card hold:");
            var result = Console.ReadLine();
            int a =  Convert.ToInt32(result);
            if( holds[a - 1] == false)
                holds[a - 1] = true;
            else
                holds[a - 1] = false;
        }

        public static void showTable(bool[] holds)
        {

            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0,-19}",(i + 1) + ". " + table[i].getCard());
                //string str = (i + 1).ToString() + ". " + table[i].getCard().ToString();
                if (holds[i] == true)
                    Console.WriteLine(" HOLD");
                else
                    Console.WriteLine();
    
            }
            
        }

        public static int DisplayMenu()
        {
            Console.WriteLine("---Menu---");
            Console.WriteLine("1. Deal/Draw");
            Console.WriteLine("2. Hold/Unhold");
            Console.WriteLine("0. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
