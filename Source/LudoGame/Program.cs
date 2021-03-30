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
                SquareList.Add(new Square(i));
            }
        }
    }

    // Skapa bräde med rätt antal rutor
    // Fråga efter antal spelare
    // Spelare väljer färg
    // Skapa startruta för varje färg
    // Slå tärning, random är först, eller röd
    // bara tillåtet med 1 eller 6 på första draget
    // ruta sparar vem som står där
    // om en till kliver på ruta kastar ruta ut den första
    // 

    class Square
    {
        Piece piece { get ; set; }
        int squareNr { get; set; }
        public Square(int Id)
        {
            squareNr = Id;
        }
    }

    class WinSquare
    {
        
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
