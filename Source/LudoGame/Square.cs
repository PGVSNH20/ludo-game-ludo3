using System;

namespace LudoGame
{
    public class Square
    {
        public Piece SquarePiece { get; set; }
        public int SquareId { get; set; }

        public void MoveHere(Piece piece)
        {
            if (SquarePiece != null)
            {
                SquarePiece.isAlive = false;
                //todo: flyta tillbaka pjäs till start om den blir knuffad
                Console.WriteLine($"{SquarePiece.Color} has lost a piece, {piece.Color} has taken the square");
                SquarePiece = piece;
            }
            else SquarePiece = piece;
            piece.CurrentSquare = this;
        }
    }
}