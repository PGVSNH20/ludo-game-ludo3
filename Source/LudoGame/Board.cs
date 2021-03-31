using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    public class Board
    {
        //finns det bättre sätt än att ha 40 rutor igång?
        private static List<Square> SquareList = new();

        public static void MakeSquares()
        {
            for (var i = 0; i < 40; i++)
            {
                SquareList.Add(new Square(i));
            }
        }

        //flytta antal steg framåt till ny ruta
        public static void MoveTo(int diceroll, Piece piece)
        {
            var squareQuery = SquareList.Single(square => square.SquareNr == (piece.CurrentSquare.SquareNr + diceroll));
            squareQuery.Move(piece);
            Console.WriteLine($"Moved to square nr: {squareQuery.SquareNr}");
        }

        //Välj färg, något ToLowerCase eller liknande behövs
        public static string ChooseColor()
        {
            List<string> Colors = new() { "Red", "Green", "Yellow", "Blue" };
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

        //välj antal spelare och returnera
        public static List<Player> MakePlayers()
        {
            List<Player> Players = new();

            //Hur många spelare?
            int numberOfPlayers = 0;
            Console.WriteLine("How many players?");
            //allt följande bör ändras
            while (numberOfPlayers != 2 && numberOfPlayers != 3 && numberOfPlayers != 4)
            {
                numberOfPlayers = Int32.Parse(Console.ReadLine());
            }

            //Varje spelare väljer färg och får en startruta
            for (var i = 0; i < numberOfPlayers; i++)
            {
                Console.Clear();
                Console.WriteLine("Player {0} select a color:", (i + 1));
                var color = ChooseColor();
                var startsquare = MakeStartSquare(i);
                Player player = new(color, startsquare);
                player.MakePieces();
                Players.Add(player);
            }

            //returnerar alla spelare
            return Players;
        }

        //startruta
        private static Square MakeStartSquare(int i)
        {
            //hur tänkte jag?   måste ändras    kanske ..
            // det funkar? player1 startar på 0, player2 på 10, player3 på 20 osv
            var square = SquareList.Single(square => square.SquareNr == (i + (i * 9)));
            return square;
        }
    }
}