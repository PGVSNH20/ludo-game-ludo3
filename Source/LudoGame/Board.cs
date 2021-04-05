using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    public class Board
    {
        //finns det bättre sätt än att ha 40 rutor igång?
        public List<Square> SquareList { get; set; } = new();
        public List<Player> Players { get; set; } = new();

        public List<Square> MakeSquares()
        {
            //hur många rutor ska vi ha?
            for (var i = 1; i <= 40; i++)
            {
                SquareList.Add(new Square(i));
            }
            return SquareList;
        }

        //flytta antal steg framåt till ny ruta
        public void MoveTo(int diceroll, Piece piece)
        {
            //addera nuvarande ruta med tärningskast för att hitta nya rutan, flytta dit
            try
            {
                var squareQuery = SquareList.FirstOrDefault(square => square.SquareNr == (piece.CurrentSquare.SquareNr + diceroll));
                squareQuery.Move(piece);
                Console.WriteLine($"Moved to square nr: {squareQuery.SquareNr}");
            }
            catch (NullReferenceException)
            {
                //todo: flytta tillbaka när vi klivit över sista rutan
                throw new NotImplementedException();
            }
        }

        //Välj färg, något ToLowerCase eller liknande behövs
        public static string ChooseColor(string input)
        {
            List<string> Colors = new() { "Red", "Green", "Yellow", "Blue" };
            while (!Colors.Contains(input))
            {
                Console.WriteLine("Choose a color: ");
                foreach (string color in Colors)
                {
                    Console.WriteLine(color);
                }
                input = Console.ReadLine();
            }
            return input;
        }

        //välj antal spelare och returnera
        public void MakePlayers(int numberOfPlayers)
        {
            //Varje spelare väljer färg och får en startruta
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.WriteLine("Player {0} select a color:", (i));
                string input = Console.ReadLine();
                string color = ChooseColor(input);
                Square startsquare = MakeStartSquare(i);
                Player player = new(color, startsquare);
                player.MakePieces();
                Players.Add(player);
            }
        }

        //startruta
        public Square MakeStartSquare(int i)
        {
            //hur tänkte jag?   måste ändras    kanske ..
            // det funkar? player1 startar på 0, player2 på 10, player3 på 20 osv
            var square = SquareList.SingleOrDefault(square => square.SquareNr == (i + (i * 9)));
            return square;
        }
    }
}