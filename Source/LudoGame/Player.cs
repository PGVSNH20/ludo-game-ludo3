using System;
using System.Collections.Generic;

namespace LudoGame
{
    public class Player
    {
        public string Color { get; set; }
        public string Name { get;  }
        public Square StartSquare;
        public List<Piece> Pieces = new();
        public int Score { get; set; }

        public Player(string color, Square startsquare)
        {
            Color = color;
            StartSquare = startsquare;
        }

        //Skapa 4 pjäser
        public void MakePieces()
        {
            for (var i = 0; i < 4; i++)
            {
                Pieces.Add(new Piece(true, StartSquare, Color));
            }
        }

        //Vilken pjäs flyttas? ska man välja det själv?
        public Piece SelectPiece()
        {
            Console.WriteLine("1 | 2 | 3 | 4");
            int piecenr = 0;
            while (piecenr != 1 && piecenr != 2 && piecenr != 3 && piecenr != 4)
            {
                piecenr = Int32.Parse(Console.ReadLine());
            }

            Piece piece = Pieces[piecenr - 1];
            if (piece.isAlive == true)
            {
                return piece;

            }
            else
            {
                Console.WriteLine($"The selected piece is dead, you have {Pieces.Count} pieces left");
                SelectPiece();
            }
            return piece;


        //    public Color Color { get; }
        //    public string Name { get; }
        //    public int Turn = 0;
        //    public int Score { get; set; }

        //    public List<Piece> Piece = new List<Piece>();

        //    public Player(Color color, string name)
        //    {
        //        Color = color;
        //        Name = name;
        //        Score = 0;
        //        Pieces.Add(new Piece() { GamePieceID = 1, position = new Position() { BoardPosition = 0, positionType = PositionType.StartingPosition } });
        //        Pieces.Add(new Piece() { GamePieceID = 2, position = new Position() { BoardPosition = 0, positionType = PositionType.StartingPosition } });
        //        Pieces.Add(new Piece() { GamePieceID = 3, position = new Position() { BoardPosition = 0, positionType = PositionType.StartingPosition } });
        //        Pieces.Add(new Piece() { GamePieceID = 4, position = new Position() { BoardPosition = 0, positionType = PositionType.StartingPosition } });
        //    }
        }
    }
}