using System.Collections.Generic;

namespace LudoGame
{
    public interface IPlayer
    {
        string Color { get; }
        List<Piece> Pieces { get; set; }
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
    }

    public class BluePlayer : IPlayer
    {
        public string Color { get; } = "blue";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }

    public class RedPlayer : IPlayer
    {
        public string Color { get; } = "red";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }
    public class YellowPlayer : IPlayer
    {
        public string Color { get; } = "yellow";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }

    public class GreenPlayer : IPlayer
    {
        public string Color { get; } = "green";
        public Nest StartSquare { get; set; }
        public List<InnerSquare> WinSquares { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }
}