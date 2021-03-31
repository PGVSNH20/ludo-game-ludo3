namespace LudoGame
{
    public class Piece
    {
        public bool isAlive;
        public Square CurrentSquare;
        public string Color;

        public Piece(bool isalive, Square currentsquare, string color)
        {
            isAlive = isalive;
            CurrentSquare = currentsquare;
            Color = color;
        }
    }
}