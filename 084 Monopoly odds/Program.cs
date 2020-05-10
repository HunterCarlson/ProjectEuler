using System;
using System.Collections.Generic;
using System.Linq;
using MyMathFunctions;

namespace _084_Monopoly_odds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //In the game, Monopoly, the standard board is set up in the following way:
            //https://projecteuler.net/problem=84

            //By starting at GO and numbering the squares sequentially from 00 to 39 
            //we can concatenate these two-digit numbers to produce strings that correspond with sets of squares.

            //Statistically it can be shown that the three most popular squares, in order, 
            //are JAIL (6.24%) = Square 10, E3 (3.18%) = Square 24, and GO (3.09%) = Square 00. 
            //So these three most popular squares can be listed with the six-digit modal string: 102400.

            //If, instead of using two 6-sided dice, two 4-sided dice are used, find the six-digit modal string.

            /*Notes:
             * Do the problem with two 6-sided dice first, so you can check the answer
             * 
             * Complex problem - go with monte-carlo method
             * simulate lots of moves and record results
             */

            const int turns = 20000000;
            var game = new MonopolyGame();
            game.PlayNTurns(turns);

            var stats = game.Board.GameSquares.OrderByDescending(x => x.TimesVisited);
            foreach (GameSquare square in stats)
            {
                Console.WriteLine("Square {0} visited {1} %", square.Index, 100.0 * square.TimesVisited/turns);
            }

            

            int dummy = 0;

            Console.Read();
        }
    }

    public static class GlobalVar
    {
        public const int NumSquares = 40;
        public static readonly int[] ChanceIndexes = {7, 22, 36};
        public static readonly int[] ComChestIndexes = {2, 17, 33};
    }

    internal abstract class Deck
    {
        private const int NumCards = 16;
        private int _card;

        public int Card
        {
            get { return _card; }
            set
            {
                if (value >= NumCards)
                {
                    _card = value%NumCards;
                }
                else
                {
                    _card = value;
                }
            }
        }

        public abstract void Draw(Player player);
    }

    internal class ChanceDeck : Deck
    {
        public ChanceDeck()
        {
            Card = 0;
        }

        public override void Draw(Player player)
        {
            switch (Card)
            {
                    //Advance to GO
                case 0:
                    player.GoTo(SquareName.Go);
                    break;
                    //Go to JAIL
                case 1:
                    player.GoTo(SquareName.Jail);
                    break;
                    //Go to C1
                case 2:
                    player.GoTo(SquareName.C1);
                    break;
                    //Go to E3
                case 3:
                    player.GoTo(SquareName.E3);
                    break;
                    //Go to H2
                case 4:
                    player.GoTo(SquareName.H2);
                    break;
                    //Go to R1
                case 5:
                    player.GoTo(SquareName.R1);
                    break;
                    //Go to next R (railway company)
                case 6:
                case 7:
                    player.GoToNextRailway();
                    break;
                    //Go to next U (utility company)
                case 8:
                    player.GoToNextUtility();
                    break;
                    //Go back 3 squares.
                case 9:
                    player.Move(-3);
                    break;
            }
            Card++;
        }
    }

    internal class ComChestDeck : Deck
    {
        public ComChestDeck()
        {
            Card = 0;
        }
        public override void Draw(Player player)
        {
            switch (Card)
            {
                //Advance to GO
                case 0:
                    player.GoTo(SquareName.Go);
                    break;
                //Go to JAIL
                case 1:
                    player.GoTo(SquareName.Jail);
                    break;
            }
            Card++;
        }

    }

    internal class Dice
    {
        private readonly int numSides;
        private readonly Random r;
        private int d1;
        private int d2;
        private int doubleInARow;

        public Dice(int numSides)
        {
            r = new Random();
            this.numSides = numSides;
            doubleInARow = 0;
            Roll();
        }

        public void Roll()
        {
            d1 = r.Next(1, numSides + 1);
            d2 = r.Next(1, numSides + 1);
            if (IsDoubles())
            {
                doubleInARow++;
            }
            else
            {
                doubleInARow = 0;
            }
        }

        public int Value()
        {
            return d1 + d2;
        }

        public bool IsDoubles()
        {
            return d1 == d2;
        }

        public bool IsThirdDouble()
        {
            if (doubleInARow == 3)
            {
                //reset doubles count
                doubleInARow = 0;
                return true;
            }
            return false;
        }
    }

    internal class Player
    {
        private int _square;

        public Player()
        {
            Square = (int) SquareName.Go;
        }

        public int Square
        {
            get { return _square; }
            set
            {
                if (value >= GlobalVar.NumSquares || value < 0)
                {
                    _square = MathFunctions.Mod(value, GlobalVar.NumSquares);
                }
                else
                {
                    _square = value;
                }
            }
        }

        public void GoTo(SquareName square)
        {
            Square = (int) square;
        }

        public void Move(int numSpaces)
        {
            Square = Square + numSpaces;
        }

        public void GoToNextRailway()
        {
            if (Square < (int) SquareName.R1)
            {
                GoTo(SquareName.R1);
            }
            else if (Square < (int) SquareName.R2)
            {
                GoTo(SquareName.R2);
            }
            else if (Square < (int)SquareName.R3)
            {
                GoTo(SquareName.R3);
            }
            else if (Square < (int)SquareName.R4)
            {
                GoTo(SquareName.R4);
            }
            //squares after R4, but before R1
            else
            {
                GoTo(SquareName.R1);
            }
        }

        public void GoToNextUtility()
        {
            if (Square < (int) SquareName.U1)
            {
                GoTo(SquareName.U1);
            }
            else if (Square < (int) SquareName.U2)
            {
                GoTo(SquareName.U2);
            }
            //squares after U2, but before U1
            else
            {
                GoTo(SquareName.U1);
            }
        }
    }

    internal class GameSquare
    {
        public GameSquare(int index, SquareEvent squareEvent = SquareEvent.None)
        {
            Index = index;
            SquareEvent = squareEvent;
            TimesVisited = 0;
        }

        public SquareEvent SquareEvent { get; set; }
        public int TimesVisited { get; set; }
        public int Index { get; set; }
    }

    internal enum SquareEvent
    {
        None = 0,
        GoToJail,
        DrawChance,
        DrawComChest
    }

    internal enum SquareName
    {
        Go = 0,
        Jail = 10,
        GoToJail = 30,
        C1 = 11,
        E3 = 24,
        H2 = 39,
        R1 = 5,
        R2 = 15,
        R3 = 25,
        R4 = 35,
        U1 = 12,
        U2 = 28
    }

    internal class GameBoard
    {
        public GameBoard()
        {
            GameSquares = new List<GameSquare>();
            for (int i = 0; i < GlobalVar.NumSquares; i++)
            {
                SquareEvent tempEvent;
                if (i == (int)SquareName.GoToJail)
                {
                    tempEvent = SquareEvent.GoToJail;
                }
                else if (GlobalVar.ChanceIndexes.Contains(i))
                {
                    tempEvent = SquareEvent.DrawChance;
                }
                else if (GlobalVar.ComChestIndexes.Contains(i))
                {
                    tempEvent = SquareEvent.DrawComChest;
                }
                else
                {
                    tempEvent = SquareEvent.None;
                }
                GameSquares.Add(new GameSquare(i, tempEvent));
            }
            GameSquares = GameSquares.OrderBy(x => x.Index).ToList();
        }

        public List<GameSquare> GameSquares { get; set; }
    }

    internal class MonopolyGame
    {
        public MonopolyGame()
        {
            Player = new Player();
            //Dice = new Dice(6);
            Dice = new Dice(4);
            ChanceDeck = new ChanceDeck();
            ComChestDeck = new ComChestDeck();
            Board = new GameBoard();
        }

        public Player Player { get; set; }
        public GameBoard Board { get; set; }
        public Dice Dice { get; set; }
        public ChanceDeck ChanceDeck { get; set; }
        public ComChestDeck ComChestDeck { get; set; }


        public void PlayNTurns(int turns)
        {
            for (int i = 0; i < turns; i++)
            {
                PlayTurn();
            }
        }

        private void PlayTurn()
        {
            //roll the dice
            Dice.Roll();

            //carry out result of roll
            //3 doubles in a row = jail
            if (Dice.IsThirdDouble())
            {
                Player.GoTo(SquareName.Jail);
            }
            else
            {
                Player.Move(Dice.Value());
            }

            //carry out other results if applicable
            switch (Board.GameSquares[Player.Square].SquareEvent)
            {
                case SquareEvent.GoToJail:
                    Player.GoTo(SquareName.Jail);
                    break;
                case SquareEvent.DrawChance:
                    ChanceDeck.Draw(Player);
                    break;
                case SquareEvent.DrawComChest:
                    ComChestDeck.Draw(Player);
                    break;
            }

            //update square stats
            Board.GameSquares[Player.Square].TimesVisited++;
        }
    }
}