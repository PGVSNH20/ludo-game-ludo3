using System.Collections.Generic;

namespace LudoGame
{
    public interface IPlayer
    {
        public int PlayerId { get; set; }
        string Color { get; set; }
        List<Piece> Pieces { get; set; }
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
    }

    public class BluePlayer : IPlayer
    {
        public string Color { get; set; } = "blue";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
        public int PlayerId { get; set; }
    }

    public class RedPlayer : IPlayer
    {
        public string Color { get; set; } = "red";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
        public int PlayerId { get; set; }
    }

    public class YellowPlayer : IPlayer
    {
        public string Color { get; set; } = "yellow";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
        public int PlayerId { get; set; }
    }

    public class GreenPlayer : IPlayer
    {
        public string Color { get; set; } = "green";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
        public int PlayerId { get; set; }
    }
}