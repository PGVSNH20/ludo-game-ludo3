namespace LudoGame
{
    public class Piece
    {
        public bool isAlive { get; set; } = false;
        public Square CurrentSquare { get; set; }
        public string Color { get; set; }
        public string Steps { get; set; }
        public int PieceId { get; set; }
    }
}