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
            int steps = SquareId - piece.CurrentSquare.SquareId;
            piece.Steps += steps;
            //tilldela ruta
            SquarePiece = piece;
            piece.CurrentSquare = this;
        }
    }
}