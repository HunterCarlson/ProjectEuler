using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _054_Poker_hands
{
    internal enum Ranks
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush,
        NotRanked = 0,
    }

    public enum Suits
    {
        Clubs = 1,
        Hearts = 2,
        Spades = 3,
        Diamonds = 4
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            //In the card game poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:

            //    High Card: Highest value card.
            //    One Pair: Two cards of the same value.
            //    Two Pairs: Two different pairs.
            //    Three of a Kind: Three cards of the same value.
            //    Straight: All cards are consecutive values.
            //    Flush: All cards of the same suit.
            //    Full House: Three of a kind and a pair.
            //    Four of a Kind: Four cards of the same value.
            //    Straight Flush: All cards are consecutive values of same suit.
            //    Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.

            //The cards are valued in the order:
            //2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.

            //If two players have the same ranked hands then the rank made up of the highest value wins; 
            //for example, a pair of eights beats a pair of fives (see example 1 below). 
            //But if two ranks tie, for example, both players have a pair of queens, then highest cards in each hand are compared 
            //(see example 4 below); if the highest cards tie then the next highest cards are compared, and so on.

            //The file, poker.txt, contains one-thousand random hands dealt to two players. 
            //Each line of the file contains ten cards (separated by a single space): 
            //the first five are Player 1's cards and the last five are Player 2's cards.
            //You can assume that all hands are valid (no invalid characters or repeated cards),
            //each player's hand is in no specific order, and in each hand there is a clear winner.

            //How many hands does Player 1 win?


            var list = new List<string> {"a", "b", "d", "a", "c", "a", "b", "d", "d"};
            var q = from x in list
                group x by x
                into g
                let count = g.Count()
                orderby count descending
                select new {Value = g.Key, Count = count};
            foreach (var x in q)
            {
                Console.WriteLine("Value: " + x.Value + " Count: " + x.Count);
            }


            Hand royalFlush = CardsStringToHand("AS TS JS QS KS");
            Console.WriteLine(royalFlush.Rank);
            Hand straightFlush = CardsStringToHand("6C 7C 9C 8C 5C");
            Console.WriteLine(straightFlush.Rank);
            Hand fourOfAKind = CardsStringToHand("7C 7H 5C 7S 7D");
            Console.WriteLine(fourOfAKind.Rank);
            Hand fullHouse = CardsStringToHand("2H 2D 4C 4D 4S");
            Console.WriteLine(fullHouse.Rank);
            Hand twoPair = CardsStringToHand("2D 4H 5H 2C 4D");
            Console.WriteLine(twoPair.Rank);



            const int handSize = 5;
            const int numHands = 1000;
            int p1WinCount = 0;
            const string filename = "poker.txt";
            //const string filename = "PokerTests.txt";
            var r = new StreamReader(filename);
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                string p1CardString = line.Substring(0, line.Length / 2);
                string p2CardString = line.Substring(line.Length / 2 + 1);
                Hand p1Hand = CardsStringToHand(p1CardString);
                Hand p2Hand = CardsStringToHand(p2CardString);

                if (Winner(p1Hand, p2Hand) == 1)
                {
                    p1WinCount++;
                }
            }
            r.Close();

            Console.WriteLine(p1WinCount);

            Console.Read();
        }
        
        

        private static int Winner(Hand p1Hand, Hand p2Hand)
        {
            if (p1Hand.Rank > p2Hand.Rank)
            {
                return 1;
            }
            if (p2Hand.Rank > p1Hand.Rank)
            {
                return 2;
            }
            if (p1Hand.Rank == p2Hand.Rank)
            {
                //tiebreakers

                if (p1Hand.Rank == Ranks.FourOfAKind
                    || p1Hand.Rank == Ranks.FullHouse
                    || p1Hand.Rank == Ranks.ThreeOfAKind
                    || p1Hand.Rank == Ranks.OnePair)
                {
                    for (int i = 0; i < p1Hand.Values.Count; i++)
                    {
                        if (p1Hand.Values[i] > p2Hand.Values[i])
                        {
                            return 1;
                        }
                        if (p2Hand.Values[i] > p1Hand.Values[i])
                        {
                            return 2;
                        }
                    }
                }
                if (p1Hand.Rank == Ranks.StraightFlush
                    || p1Hand.Rank == Ranks.Flush
                    || p1Hand.Rank == Ranks.Straight
                    || p1Hand.Rank == Ranks.HighCard)
                {
                    p1Hand.Values.Sort();
                    p1Hand.Values.Reverse();
                    p2Hand.Values.Sort();
                    p2Hand.Values.Reverse();

                    for (int i = 0; i < p1Hand.Values.Count; i++)
                    {
                        if (p1Hand.Values[i] > p2Hand.Values[i])
                        {
                            return 1;
                        }
                        if (p2Hand.Values[i] > p1Hand.Values[i])
                        {
                            return 2;
                        }
                    }
                }
                if (p1Hand.Rank == Ranks.TwoPairs)
                {
                    p1Hand.Values.Sort();
                    p2Hand.Values.Sort();
                    //no 2 pairs??
                }
            }
            throw new Exception("ties should happen with this data set");
        }

        private static Hand CardsStringToHand(string cardsString)
        {
            string[] cardsStrings = cardsString.Split(' ');
            var cards = cardsStrings.Select(s => new Card(s)).ToList();
            return new Hand(cards);
        }
    }


    internal class Card
    {
        public Card(string cardString)
        {
            const string valueString = "23456789TJQKA";
            const string suitsString = "CHSD";
            if (cardString.Length != 2)
            {
                throw new Exception("Card string must be 2 characters long");
            }
            if (!valueString.Contains(cardString[0]))
            {
                throw new Exception("cardString[0] must be a value A23456789TJQK");
            }
            if (!suitsString.Contains(cardString[1]))
            {
                throw new Exception("cardString[1] must be a suit in CHSD");
            }

            Value = valueString.IndexOf(cardString[0]) + 2; //+2 because zero indedx and first value = 2 
            Suit = (Suits) suitsString.IndexOf(cardString[1]) + 1; //+1 because zero index
        }

        public int Value { get; private set; }
        public Suits Suit { get; private set; }
    }

    internal class Hand
    {
        public Hand(List<Card> cards)
        {
            Cards = cards;
            GetCountsAndValues();
            GetRank();
        }

        public List<Card> Cards { get; private set; }
        public Ranks Rank { get; private set; }
        public List<int> Counts { get; private set; }
        public List<int> Values { get; private set; }

        private void GetCountsAndValues()
        {
            var values = new List<int>();
            var counts = new List<int>();

            List<int> list = Cards.Select(card => card.Value).ToList();
            var q = from x in list
                group x by x
                into g
                let count = g.Count()
                orderby count descending 
                select new {Value = g.Key, Count = count};
            foreach (var x in q)
            {
                //Console.WriteLine("Value: " + x.Value + " Count: " + x.Count);
                values.Add(x.Value);
                counts.Add(x.Count);
            }
            Counts = counts;
            Values = values;
        }

        private void GetRank()
        {
            //royal flush is just an ace high straight flush
            if (IsStraightFlush()) Rank = Ranks.StraightFlush;
            else if (IsFourOfAKind()) Rank = Ranks.FourOfAKind;
            else if (IsFullHouse()) Rank = Ranks.FullHouse;
            else if (IsFlush()) Rank = Ranks.Flush;
            else if (IsStraight()) Rank = Ranks.Straight;
            else if (IsThreeOfAKind()) Rank = Ranks.ThreeOfAKind;
            else if (IsTwoPairs()) Rank = Ranks.TwoPairs;
            else if (IsOnePair()) Rank = Ranks.OnePair;
            else Rank = Ranks.HighCard;
        }

        private bool IsOnePair()
        {
            return Counts[0] == 2;
        }

        private bool IsTwoPairs()
        {
            return Counts[0] == 2
                   && Counts[1] == 2;
        }

        private bool IsThreeOfAKind()
        {
            return Counts[0] == 3;
        }

        private bool IsFullHouse()
        {
            return Counts[0] == 3
                   && Counts[1] == 2;
        }


        private bool IsFourOfAKind()
        {
            return Counts[0] == 4;
        }

        private bool IsStraightFlush()
        {
            return IsStraight()
                   && IsFlush();
        }

        private bool IsStraight()
        {
            return Counts.Count == 5
                   && Values.Max() - Values.Min() == 4;
        }

        private bool IsFlush()
        {
            return Cards.All(card => card.Suit == Cards.First().Suit);
        }
    }
}