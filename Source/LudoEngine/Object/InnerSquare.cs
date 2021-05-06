namespace LudoGame
{
    public class InnerSquare : ISquare
    {
        public int InnerSquareId { get; set; }
        public Piece SquarePiece { get; set; }
        public int? PieceId { get; set; }
        public Square Square { get; set; }
        public int SquareId { get; set; }
    }

    public interface ISquare
    {
        public Piece SquarePiece { get; set; }
        public int SquareId { get; set; }
    }
}