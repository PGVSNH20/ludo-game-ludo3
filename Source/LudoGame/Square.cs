using System;

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

        public void Move(Piece piece)
        {
            //en pjäs landar på rutan
            if (Piece == null)
            {
                Piece = piece;
                Piece.CurrentSquare = this;
            }
            else
            {
                //kanske finns bättre sätt att 'döda' den?
                Piece.isAlive = false; 
                Console.WriteLine($"{Piece.Color} has lost a piece, {piece.Color} has taken its place");
                Piece = piece;
            }
        }
    }
}