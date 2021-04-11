using System;

namespace LudoGame
{
    public class Square : ISquare
    {
        public Piece SquarePiece { get; set; }
        public int SquareId { get; set; }
        public void MoveHere(Piece piece)
        {
            //lägg till antal steg
            int steps = this.SquareId - piece.CurrentSquare.SquareId;
            piece.Steps += steps;
            //om det står en pjäs av annan färg, knuffa den
            if (SquarePiece != null && SquarePiece.Color != piece.Color)
            {
                SquarePiece.IsAlive = false;
                //todo: flyta tillbaka pjäs till start om den blir knuffad
                Console.WriteLine($"{SquarePiece.Color} has lost a piece, {piece.Color} has taken the square");
                SquarePiece = piece;
            }
            else SquarePiece = piece;
            piece.CurrentSquare = this;
        }
    }
}