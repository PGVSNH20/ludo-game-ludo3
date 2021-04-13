using System.ComponentModel.DataAnnotations.Schema;

namespace LudoGame
{
    public class Piece
    {
        public int PieceId { get; set; }
        public bool IsAlive { get; set; } = false;

        [NotMapped]
        public ISquare CurrentSquare { get; set; }

        public int CurrentSquareNr { get; set; }
        public string Color { get; set; }
        public int Steps { get; set; }
        public int PieceNr { get; set; }
        public int PlayerId { get; set; }
    }
}