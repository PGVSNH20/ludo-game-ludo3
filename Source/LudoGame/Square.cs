using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    public class Square
    {
        public Piece Piece { get; set; }
        public int SquareNr { get; set; }

        public Square(int Id)
        {
            SquareNr = Id;
        }

        internal void Move(Piece piece)
        {
            //en pjäs landar på rutan
            if (Piece == null) Piece = piece;
            else
            {
                //kanske finns bättre sätt att 'döda' den?
                Piece.isAlive = false;
                Piece = piece;
                Console.WriteLine($"{Piece} is dead, {piece} has taken its place");
            }
        }
    }
}