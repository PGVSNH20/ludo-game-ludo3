namespace LudoGame
{
    public class Piece
    {
        public bool isAlive { get; set; }
        public Square CurrentSquare { get; set; }
        public string Color { get; set; }

        public Piece(bool isalive, Square currentsquare, string color)
        {
            isAlive = isalive;
            CurrentSquare = currentsquare;
            Color = color;
        }
    }
}