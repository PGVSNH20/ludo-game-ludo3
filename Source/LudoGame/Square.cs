using System;

namespace LudoGame
{
    public class Square
    {
        public Piece SquarePiece { get; set; }
        public int SquareId { get; set; }

        //min pjäs (står på 20) vill flytta hit
        public void MoveHere(Piece piece)
        {
            if (SquarePiece != null)
            {
                SquarePiece.isAlive = false;
                Console.WriteLine($"{SquarePiece.Color} has lost a piece, {piece.Color} has taken the square");
                SquarePiece = piece;
            }
            else SquarePiece = piece;
            piece.CurrentSquare = this;
        }
    }
}