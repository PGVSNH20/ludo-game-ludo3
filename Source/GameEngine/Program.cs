using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Piece
    {
        bool isAlive;
        int CurrentSquare;
        string Color;
    }

    class Board
    {
        List<Square> SquareList = new List<Square>();
        void MakeSquares()
        {
            for (var i = 0; i < 40; i++)
            {
                SquareList.Add(new Square());
            }
        }
    }

    // Skapa bräde med rätt antal rutor
    // Fråga efter antal spelare
    // Spelare väljer färg
    // Skapa startruta för varje färg
    // 

    class Square
    {
        Piece piece;
        int squareNr;
    }

    class Dice
    {
        Random rand = new Random();

        public int RollDice()
        {
            int diceroll = rand.Next(0, 6);
            return diceroll;
        }
    }

    class StartLudo
    {
        List<int> numberOfPlayers = new List<int> ();

        List<string> Colors = new List<string>() { "Red", "Green", "Yellow", "Blue" };

        public string ChooseColor()
        {
            string input = null;
            while (!Colors.Contains(input))
            {
                Console.WriteLine("Choose a color: ");
                foreach (var color in Colors)
                {
                    Console.WriteLine(color);
                }
                input = Console.ReadLine();
            }
            return input;
        }

        public void MakeBoard()
        {
            for (var i = 0; i < numberOfPlayers.Count;)
            {
                var color = ChooseColor();
                Player player = new Player(color);
            }
        }
    }

    class Player
    {
        string Color { get; set; }
        public Player(string color)
        {
            Color = color;
        }
    }
}
