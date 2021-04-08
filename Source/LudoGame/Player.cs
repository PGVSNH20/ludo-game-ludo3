using System.Collections.Generic;

namespace LudoGame
{
    public interface IPlayer
    {
        string Color { get; }
        List<Piece> Pieces { get; set; }
        public Square StartSquare { get; set; }
        public Square WinSquare { get; set; }
    }

    public class BluePlayer : IPlayer
    {
        public string Color { get; } = "blue";
        public Square StartSquare { get; set; }
        public Square WinSquare { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }

    public class RedPlayer : IPlayer
    {
        public string Color { get; } = "red";
        public Square StartSquare { get; set; }
        public Square WinSquare { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }
    public class YellowPlayer : IPlayer
    {
        public string Color { get; } = "yellow";
        public Square StartSquare { get; set; }
        public Square WinSquare { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }

    public class GreenPlayer : IPlayer
    {
        public string Color { get; } = "green";
        public Square StartSquare { get; set; }
        public Square WinSquare { get; set; }
        public List<Piece> Pieces { get; set; } = new();
    }
}