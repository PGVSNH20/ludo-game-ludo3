namespace LudoGame
{
    public class Piece
    {
        public bool IsAlive { get; set; } = false;
        public ISquare CurrentSquare { get; set; }
        public string Color { get; set; }
        public int Steps { get; set; }
        public int PieceId { get; set; }
    }
}