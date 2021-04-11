using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    public class Game
    {
        public List<IPlayer> Players { get; set; } = new();
        public Board Board { get; set; }
        public InnerSquare Winsquare { get; set; } = new();

        //välj färg själv
        public List<IPlayer> ColorSelect(int nrOfPlayers, List<IPlayer> availablePlayers)
        {
            //skriv ut tillgängliga färger och spara det
            Console.WriteLine("Available colors: \n");
            List<string> availableColors = new();
            List<IPlayer> players = new();
            foreach (var player in availablePlayers)
            {
                Console.WriteLine(player.Color);
                availableColors.Add(player.Color);
            }
            //fråga om en färg för varje spelare
            for (int i = 0; i < nrOfPlayers; i++)
            {
                Console.WriteLine($"\nPlayer {i+1} select a color");
                string input = Console.ReadLine().ToLower();
                //om färgen matchar tillgänglig färg får man den, tas bort ur lista när man väljer så ingen annan kan ta samma
                while (!availableColors.Contains(input))
                {
                    input = Console.ReadLine().ToLower();
                }
                //hämta klassen som matchar färg
                IPlayer player = availablePlayers.SingleOrDefault(player => player.Color == input);
                //hämta ruta 0, 10, 20, 30 för att börja på
                player.StartSquare = Board.Squares.Single(square => square.SquareId == (i + (i * 9)));
                //skapa pjäser och spara spelare
                MakePieces(player);
                players.Add(player);
            }
            //skicka tillbaka spelare
            return players;
        }
        //skapa bräde
        public void SetUpBoard(int nrOfPlayers, bool selectColors) 
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
            //välj färg automatiskt
            if (!selectColors)
            {
                for (int i = 0; i < nrOfPlayers; i++)
                {
                    //få en färg tilldelad
                    IPlayer player = AvailablePlayers[i];
                    //hämta ruta 0, 10, 20, 30 för att börja på
                    player.StartSquare = Board.Squares.Single(square => square.SquareId == (i + (i * 9)));
                    //skapa pjäser och spara spelare
                    MakePieces(player);
                    Players.Add(player);
                }
            } else
            {
                //spelare väljer färg
                Players = ColorSelect(nrOfPlayers, AvailablePlayers);
            }
        }
        //skapa pjäser
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
        //spelare börjar i sitt bo
        //hitta nästa ruta
        public Square FindNextSquare(Piece piece, int diceroll)
        {
            //tärningskast plus nuvarande ruta
            int newSquareId = (piece.CurrentSquare.SquareId + diceroll);
            //om nästa ruta är över 40, gå runt, ruta 40 blir samma ruta som ruta 0
            if (newSquareId > 40) newSquareId = newSquareId - 40;
            //hitta rutan med den siffran, eller null om den inte finns
            Square newSquare = Board.Squares.SingleOrDefault(square => square.SquareId == newSquareId);
            //skicka tbx den rutan
            return newSquare;
        }
        //flytta till en ruta
        public void MoveToSquare(Piece piece, int diceroll)
        {
            //hitta rutan med den siffran
            Square newSquare = FindNextSquare(piece, diceroll);
            //ta bort pjäsen från nuvarande ruta
            piece.CurrentSquare.SquarePiece = null;
            //gör pjäsen levande om den inte är det
            if (piece.isAlive == false) piece.isAlive = true;
            //om någon pjäs tagit mer än 40 steg, gå in i vinststräckan
            if (piece.Steps < 40)
            {
                //flytta pjäsen till nya rutan
                newSquare.MoveHere(piece);

            } else
            {
                int steps = piece.Steps - 40;
                SetUpWinSquares(piece, steps);
            }
        }
        //pjäs logik
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
            //om en pjäs är på vinststräckan
            bool pieceOnWinSquares = pieces.Any(piece => piece.CurrentSquare.GetType() == typeof(InnerSquare));

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
            if (!pieces.Any(piece => piece.isAlive == true))
            {
                if (!diceroll1or6)
                {
                    Console.WriteLine("You're not allowed to move a new piece! Next players turn. (press enter)");
                    return null;
                } else
                {
                    return newpiece;
                }
            }

            //om du kastar 1 eller 6 får du flytta vilken du vill
            if (diceroll1or6)
            {
                Console.WriteLine($"Which piece do you want to move?");
                foreach (Piece piece in pieces)
                {
                    if (piece.CurrentSquare.GetType() == typeof(Square))
                    {
                        Console.WriteLine($"{piece.PieceId}, current square: {piece.CurrentSquare.SquareId}");
                    }
                    else
                    {
                        Console.WriteLine($"{piece.PieceId}, current square on inner row: {piece.CurrentSquare.SquareId}");
                    }
                    Square square = FindNextSquare(piece, diceroll);
                    //kolla om pjäsen som blir knuffad är en annan färg, (kan man stå flera pjäser på samma ruta?)
                    //kolla om man har möjlighet att knuffa
                    if (square.SquarePiece != null && square.SquarePiece.Color != piece.Color) Console.WriteLine($"Move piece {piece.PieceId} to knuff {square.SquarePiece.Color}'s piece");
                }
                newpiece = SelectPieceUserInput(pieces);
            }

            //om du inte kastar 1 eller 6 får du bara flytta levande pjäser
            if (!diceroll1or6)
            {
                var piecesAreAlive = pieces.Where(pieces => pieces.isAlive);
                Console.WriteLine($"Which piece do you want to move?");
                foreach (Piece piece in piecesAreAlive)
                {
                    if (piece.CurrentSquare.GetType() == typeof(Square))
                    {
                        Console.WriteLine($"{piece.PieceId}, current square: {piece.CurrentSquare.SquareId}");
                    } else
                    {
                        Console.WriteLine($"{piece.PieceId}, current square on inner row: {piece.CurrentSquare.SquareId}");
                    }
                }
                newpiece = SelectPieceUserInput(piecesAreAlive.ToList());
            }

            //ska returnera en pjäs
            return newpiece;
        }
        //spelare väljer pjäs
        public Piece SelectPieceUserInput(List<Piece> pieces)
        {
            //todo: felhantera user input om t.ex enter
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
        //skapa vinststräcka
        public void SetUpWinSquares(Piece piece, int steps)
        {
            //hitta spelaren
            var player = Players.SingleOrDefault(player => player.Color == piece.Color);
            List<InnerSquare> squares = new();
            // 4 rutor skapas (1 - 5) 
            for (int i = 1; i < 5; i++)
            {
                InnerSquare square = new();
                square.SquareId = i;
                squares.Add(square);
            }
            //vinstruta
            Winsquare.SquareId = 5;
            squares.Add(Winsquare);

            //hitta rutan du landar på
            InnerSquare square0 = squares.SingleOrDefault(square => square.SquareId == steps);
            //ta bort från förra rutan
            piece.CurrentSquare.SquarePiece = null;
            //flytta hit pjäsen
            piece.CurrentSquare = square0;
            piece.Steps = 0;

            //lägg till inre raden
            player.WinSquares = squares;
        }

        public void WinRowMove(Piece piece, int diceroll)
        {
            //hitta spelaren
            var player = Players.SingleOrDefault(player => player.Color == piece.Color);
            //inre raden
            var squares = player.WinSquares;
            int currentSquare = piece.CurrentSquare.SquareId;
            //nya rutan
            //WinSquare newsquare = squares.SingleOrDefault(square => square.SquareId == diceroll);
            int newSquareId = currentSquare + diceroll;
            // 8
            if (newSquareId == 5)
            {

                Console.WriteLine("Congratulations you have finnished the game! You are now free from our chains and can leave to live your life!");
                player.Pieces.Remove(piece);
            } else
            {
                int winroll = 5 - currentSquare;
                Console.WriteLine($"You need to roll a {winroll}, next players turn");
            }
            //hitta rutan med id = newsquareid
            ISquare square = squares.SingleOrDefault(square => square.SquareId == newSquareId);
            //ta bort från gamla rutan
            piece.CurrentSquare.SquarePiece = null;
            //tilldela nya rutan
            piece.CurrentSquare = square;
        }
    }
}