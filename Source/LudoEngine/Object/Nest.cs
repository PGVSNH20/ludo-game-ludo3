namespace LudoGame
{
    public class Nest : ISquare
    {
        public int NestId { get; set; }
        private Square NestSquare { get; set; }
        public Piece SquarePiece { get; set; }
        public int? PieceId { get; set; }
        public Square Square { get; set; }
        public int SquareId { get; set; }

        public Nest CreateNest(int nestid)
        {
            Square square = new();
            NestSquare = square;
            SquareId = (nestid - 1);
            return this;
        }
    }
}