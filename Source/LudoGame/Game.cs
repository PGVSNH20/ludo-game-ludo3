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
    //spelare väljer pjäs, inte på första draget
    //om man inte rullar 1, 6 och alla pjäser är döda så får man inte välja en pjäs ..
    //automatiskt flytta levande pjäs om endast en lever

    //todo: om en spelare har möjlighet att knuffa ut en annan spelares pjäs vill detta visas.
    //todo: vinst streckan 
    //todo: databas
    //todo: kliva över 40 går runt, tillbak på 0

    public class EventLoop
    {
        public void GameLoop()
        {
            Game game = CreateGame();
            while (true)
            {
                RunGameMove(game);
            }
        }

        public void RunGameMove(Game game)
        {
            foreach (IPlayer player in game.Players)
            {

                //rulla tärning
                int diceroll = Dice.RollDice(player);
                //välja pjäs
                Piece piece = game.SelectPiece(player, diceroll);

                if (piece != null)
                { 
                    //spara gamla rutan för att skriva drag
                    Square oldsquare = piece.CurrentSquare;
                    //flytta pjäs
                    game.MoveToSquare(piece, diceroll);
                    //skriv ut vad som hände
                    Console.WriteLine($"Piece nr {piece.PieceId} has moved from square nr {oldsquare.SquareId} to square nr {piece.CurrentSquare.SquareId}");
                }
            }
        }

        public Game CreateGame()
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
            return game;

        }

        public bool CheckForWin()
        {
            return true;
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
        }

        public Piece SelectPiece(IPlayer player, int diceroll)
        {
            //listan av pjäser
            var pieces = player.Pieces;

            //Det här är pjäsen som ska väljas
            Piece newpiece = pieces[0];

            //om tärningskast är 1,6
            bool diceroll1or6 = diceroll == 1 || diceroll == 6;

            //om bara en lever
            bool onlyOneAlive = pieces[0].isAlive && !(pieces[1].isAlive && pieces[2].isAlive && pieces[3].isAlive);

            /*
            check whether at least one of the values is set and not all three values are set:
            bool result = (a | b | c) & !(a & b & c);
             */

            //om du inte kastar 1 eller 6 och bara en lever, flytta direkt
            if (onlyOneAlive)
            {
                if (!diceroll1or6)
                {
                    return pieces[0];
                }
            }

            //om du INTE kastar 1, 6 och alla pjäser är döda, flytta inte
            //om du kastar 1,6 och alla pjäser är döda, flytta direkt
            if (pieces.All(piece => !piece.isAlive))
            {
                if (!diceroll1or6)
                {
                    Console.WriteLine("You're not allowed to move a new piece! Next players turn. ");
                    return null;
                } else
                {
                    return newpiece;
                }
            }

            //om du kastar 1 eller 6 får du flytta vilken du vill
            if (diceroll1or6)
            {
                foreach (Piece piece in pieces)
                {
                    Console.WriteLine($"Which piece do you want to move? {piece.PieceId}, current square: {piece.CurrentSquare.SquareId}");
                }
                newpiece = SelectPieceUserInput(pieces);
            }

            //om du inte kastar 1 eller 6 får du bara flytta levande pjäser
            if (!diceroll1or6)
            {
                var piecesAreAlive = pieces.Where(pieces => pieces.isAlive);
                foreach (Piece piece in piecesAreAlive)
                {
                    Console.WriteLine($"Which piece do you want to move? {piece.PieceId}, current square: {piece.CurrentSquare.SquareId}");
                }
                newpiece = SelectPieceUserInput(piecesAreAlive.ToList());
            }

            //while (pieces.Count > 0)
            //{
            //    for (int i = 0; i < pieces.Count; i++)
            //    {
            //        if (!pieces[i].isAlive)
            //        {
            //            pieces.Remove(pieces[i]);
            //            Console.WriteLine($"Piece number {(i + 1)} is not alive and has been removed");
            //        }
            //    }

            //}

            //ska returnera en pjäs
            return newpiece;
        }

        public Piece SelectPieceUserInput(List<Piece> pieces)
        {
            //felhantera user input om t.ex enter
            //ta emot siffra från spelare
            int input = Convert.ToInt32(Console.ReadLine());

            //kolla om den pjäsen finns, annars fråga igen
            bool selectedpiecebool = pieces.Any(piece => piece.PieceId == input);
            while (!selectedpiecebool)
            {
                input = Convert.ToInt32(Console.ReadLine());
            }

            //Om pjäsen finns, skicka tillbaka den
            var selectedpiece = pieces.SingleOrDefault(piece => piece.PieceId == input);
            return selectedpiece;
        }
    }
}