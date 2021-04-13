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
        public int GameId { get; set; }
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
                Console.WriteLine($"\nPlayer {i + 1} select a color");
                string input = Console.ReadLine().ToLower();
                //om färgen matchar tillgänglig färg får man den, tas bort ur lista när man väljer så ingen annan kan ta samma
                while (!availableColors.Contains(input))
                {
                    input = Console.ReadLine().ToLower();
                }
                //hämta klassen som matchar färg
                IPlayer player = availablePlayers.SingleOrDefault(player => player.Color == input);
                //hämta ruta 0, 10, 20, 30 för att börja på
                int newsquareid = (i + (i * 9));
                Nest nest = new();
                player.StartSquare = nest.CreateNest(newsquareid);
                //player.StartSquare = Board.Squares.Single(square => square.SquareId == (i + (i * 9)));
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
                    int newsquareid = (i + (i * 9));
                    Nest nest = new();
                    player.StartSquare = nest.CreateNest(newsquareid);
                    //player.StartSquare = Board.Squares.Single(square => square.SquareId == newsquareid);
                    //skapa pjäser och spara spelare
                    MakePieces(player);
                    Players.Add(player);
                }
            }
            else
            {
                //spelare väljer färg
                Players = ColorSelect(nrOfPlayers, AvailablePlayers);
            }
        }

        //skapa pjäser
        public static void MakePieces(IPlayer player)
        {
            for (int i = 0; i < 4; i++)
            {
                Piece piece = new()
                {
                    IsAlive = false,
                    Color = player.Color,
                    CurrentSquare = player.StartSquare,
                    PieceNr = (i + 1)
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
            if (newSquareId >= 40) newSquareId -= 40;
            //spara nummer till ef för databas
            piece.CurrentSquareNr = newSquareId;
            //hitta rutan med den siffran, eller null om den inte finns
            Square newSquare = Board.Squares[newSquareId];
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
            if (piece.IsAlive == false) piece.IsAlive = true;
            //flytta pjäsen till nya rutan, knuffa om det står nån där
            bool enemyOnSquare = newSquare.SquarePiece != null && newSquare.SquarePiece.Color != piece.Color;
            Piece enemyPiece = newSquare.SquarePiece;
            if (enemyOnSquare)
            {
                Knuffa(enemyPiece);
                Console.WriteLine($"{enemyPiece.Color} has lost a piece, {piece.Color} has taken the square");
            }
            newSquare.MoveHere(piece);
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
            //hur många pjäser som lever
            int numberAlive = pieces.Count(piece => piece.IsAlive == true);
            //om en pjäs är på vinststräckan
            bool pieceOnWinSquares = pieces.Any(piece => piece.CurrentSquare.GetType() == typeof(InnerSquare));

            /*
            check whether at least one of the values is set and not all three values are set:
            bool result = (a | b | c) & !(a & b & c);
             */
            //om du inte kastar 1 eller 6 och bara en lever, flytta direkt
            if (numberAlive == 1)
            {
                if (!diceroll1or6)
                {
                    return pieces[0];
                }
            }

            //om du INTE kastar 1, 6 och alla pjäser är döda, flytta inte
            //om du kastar 1,6 och alla pjäser är döda, flytta direkt
            if (numberAlive == 0)
            {
                if (!diceroll1or6)
                {
                    Console.WriteLine("You're not allowed to move a new piece! Next players turn. (press enter)");
                    return null;
                }
                else
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
                    ISquare square = piece.CurrentSquare;
                    if (square.GetType() == typeof(Square))
                    {
                        Console.WriteLine($"{piece.PieceNr}, current square: {piece.CurrentSquare.SquareId}");
                    }
                    else if (square.GetType() == typeof(Nest))
                    {
                        Console.WriteLine($"{piece.PieceNr}, current square in nest");
                    }
                    else
                    {
                        Console.WriteLine($"{piece.PieceNr}, current square on inner row, square nr: {piece.CurrentSquare.SquareId}");
                        Console.WriteLine($"{piece.PieceNr} is {5 - square.SquareId} steps from winning");
                    }
                    Square newsquare = FindNextSquare(piece, diceroll);
                    //kolla om pjäsen som blir knuffad är en annan färg, (kan man stå flera pjäser på samma ruta?)
                    //kolla om man har möjlighet att knuffa
                    if (newsquare.SquarePiece != null && newsquare.SquarePiece.Color != piece.Color) Console.WriteLine($"Move piece {piece.PieceNr} to knuff {newsquare.SquarePiece.Color}'s piece");
                }
                newpiece = SelectPieceUserInput(pieces);
            }

            //om du inte kastar 1 eller 6 får du bara flytta levande pjäser
            if (!diceroll1or6)
            {
                var piecesAreAlive = pieces.Where(pieces => pieces.IsAlive);
                Console.WriteLine($"Which piece do you want to move?");
                foreach (Piece piece in piecesAreAlive)
                {
                    if (piece.CurrentSquare.GetType() == typeof(Square))
                    {
                        Console.WriteLine($"{piece.PieceNr}, current square: {piece.CurrentSquare.SquareId}");
                    }
                    else
                    {
                        Console.WriteLine($"{piece.PieceNr}, current square on square: {piece.CurrentSquare.SquareId}");
                    }
                }
                newpiece = SelectPieceUserInput(piecesAreAlive.ToList());
            }

            //ska returnera en pjäs
            return newpiece;
        }

        //spelare väljer pjäs
        public static Piece SelectPieceUserInput(List<Piece> pieces)
        {
            //ta emot siffra från spelare
            List<int> pieceNumbers = new();
            foreach (var piece in pieces)
            {
                pieceNumbers.Add(piece.PieceNr);
            }
            //kolla om den pjäsen finns, annars fråga igen
            bool input = Int32.TryParse(Console.ReadLine(), out int nr);
            while (!input && !pieceNumbers.Contains(nr))
            {
                Console.WriteLine("Input a valid number ( 1 - 4 )");
                input = Int32.TryParse(Console.ReadLine(), out nr);
            }
            //Skicka tillbaka den valda pjäsen
            var selectedpiece = pieces.SingleOrDefault(piece => piece.PieceNr == nr);
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

            InnerSquare square0;
            //hitta rutan du landar på
            if (steps == 0) square0 = squares[0];
            else
            {
                square0 = squares.SingleOrDefault(square => square.SquareId == steps);
            }
            //ta bort från förra rutan
            piece.CurrentSquare.SquarePiece = null;
            //flytta hit pjäsen
            piece.CurrentSquare = square0;
            square0.SquarePiece = piece;
            piece.Steps = 40;
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
            int walkback = 0;
            //om du kliver över vinstrutan
            if (newSquareId > 5)
            {
                //antal steg du klivit över
                walkback = newSquareId - 5;
                //nya rutan är det antalet steg tillbaka från vinstrutan
                newSquareId = 5 - walkback;
            }

            //ta bort från gamla rutan
            piece.CurrentSquare.SquarePiece = null;

            if (newSquareId == 5)
            {
                Console.WriteLine("Congratulations you have finnished the game! You are now free from our chains and can leave to live your life!");
                player.Pieces.Remove(piece);
            }
            else
            {
                //hitta rutan med id = newsquareid
                ISquare square = squares.SingleOrDefault(square => square.SquareId == newSquareId);
                //tilldela nya rutan
                piece.CurrentSquare = square;
            }
        }

        private void Knuffa(Piece piece)
        {
            //hitta spelare
            IPlayer player = Players.SingleOrDefault(player => player.Color == piece.Color);
            ISquare square = player.StartSquare;
            //börja om från nest
            piece.CurrentSquare = square;
            piece.Steps = 0;
            piece.IsAlive = false;
        }

        //
    }
}