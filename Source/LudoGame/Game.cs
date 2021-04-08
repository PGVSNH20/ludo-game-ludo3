using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    //varje spelare:
    //väljer färg
    //välja namn

    //pjäser skapas
    //spelbrädet skapas (square)
    //skapa bo
    //knuffa pjäser

    //spelare slår tärning

    //todo: spelare väljer pjäs, inte på första draget
    //todo: vinst streckan 
    //todo: databas
    public class EventLoop
    {
        public void GameLoop()
        {
            while (CheckForWin())
            {
                RunGame();
            }
        }

        public void RunGame()
        {
            Game game = new();

            Console.WriteLine("Welcome!");
            Console.WriteLine("Select number of players (2 - 4)");
            string input = Console.ReadLine();
            //vägrar acceptera annat än 2,3,4
            while (input != "2" && input != "3" && input != "4")
            {
                input = Console.ReadLine();
            }
            int number = Int32.Parse(input);

            //skapa bräde med antal spelare
            game.SetUpBoard(number);

            //varje spelare gör ett drag
            foreach (IPlayer player in game.Players)
            {

                //rulla tärning
                int diceroll = Dice.RollDice(player);
                //välja pjäs
                Piece piece = game.SelectPiece(player);
                //spara gamla rutan för att skriva drag
                Square oldsquare = piece.CurrentSquare;
                //flytta pjäs
                game.CheckIfAliveAndMove(piece, diceroll);
                //skriv ut vad som hände
                Console.WriteLine($"Piece nr {piece.PieceId} has moved from square nr {oldsquare.SquareId} to square nr {piece.CurrentSquare.SquareId}");
            }
        }

        public bool CheckForWin()
        {
            return false;
        }
    }

    public class Game
    {
        public List<IPlayer> Players { get; set; } = new();
        public Board Board { get; set; }

        public void SetUpBoard(int input) 
        {
            if (Board == null)
            {
                Board = new Board();
            }
            
            List<IPlayer> AvailablePlayers = new();

            AvailablePlayers.Add(new RedPlayer());
            AvailablePlayers.Add(new BluePlayer());
            AvailablePlayers.Add(new YellowPlayer());
            AvailablePlayers.Add(new GreenPlayer());


            for (int i = 0; i < input; i++)
            {
                //få en färg tilldelad
                IPlayer player = AvailablePlayers[i];
                //hämta ruta 0, 10, 20, 30 för att börja på
                Square squareQuery = Board.Squares.Single(square => square.SquareId == (i + (i * 9)));
                player.StartSquare = squareQuery;
                //skapa pjäser och spara spelare
                MakePieces(player);
                Players.Add(player);
            }
        }
        public void MakePieces(IPlayer player)
        {
            for (int i = 0; i < 4; i++)
            {
                Piece piece = new()
                {
                    isAlive = false,
                    Color = player.Color,
                    CurrentSquare = player.StartSquare,
                    PieceId = (i + 1)
                };
            player.Pieces.Add(piece);
            }
        }

        public void CheckIfAliveAndMove(Piece piece, int diceroll)
        {
            if (piece.isAlive == true)
            {
                MoveToSquare(piece, diceroll);
            } 
            else
            {
                if (diceroll != 1 && diceroll != 6)
                {
                    piece.isAlive = false;
                    Console.WriteLine("You're not allowed to move a new piece! Next players turn. ");
                } else
                {
                    piece.isAlive = true;
                    MoveToSquare(piece, diceroll);
                }
            }
        }

        public void MoveToSquare(Piece piece, int diceroll)
        {
            //tärningskast plus nuvarande ruta
            int newSquareId = (piece.CurrentSquare.SquareId + diceroll);
            //hitta rutan med den siffran
            Square newSquare = Board.Squares.Single(square => square.SquareId == newSquareId);
            //ta bort pjäsen från nuvarande ruta
            piece.CurrentSquare.SquarePiece = null;
            //flytta pjäsen till nya rutan
            newSquare.MoveHere(piece);
            //skriv ut vad som hände
        }

        public Piece SelectPiece(IPlayer player)
        {
            //listan av pjäser
            var pieces = player.Pieces;

            //skriv ut alla pjäser
            for(int i = 0; i < pieces.Count; i++)
            {
                Console.WriteLine($"Piece nr: {(i + 1)}, is alive: {pieces[i].isAlive}");
            }

            Console.WriteLine("Which piece do you want to move? (1-4)");
            int pieceinput = Convert.ToInt32(Console.ReadLine());
            //if(menuChoice >= 1 && menuChoice <= 5)
            //kör denna loop om input inte är mellan 1 och 4
            while (pieceinput <= 1 && pieceinput >= 4)
            {
                pieceinput = Convert.ToInt32(Console.ReadLine());
            }

            //piece id 
            Piece newpiece = pieces.Single(piece => piece.PieceId == pieceinput);
            return newpiece;

            //ska returnera en pjäs
        }
    }
}