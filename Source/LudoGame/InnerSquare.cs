namespace LudoGame
{
    public class InnerSquare : ISquare
    {
        public Piece SquarePiece { get; set; }
        public int SquareId { get; set; }
    }

    public interface ISquare
    {
        public Piece SquarePiece { get; set; }
        public int SquareId { get; set; }
    }
}