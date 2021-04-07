using System;
using System.Collections.Generic;

namespace LudoGame
{
    public interface IPlayer
    {
        string Color { get; }
        List<Piece> Pieces { get; }
    }

    public class BluePlayer : IPlayer
    {
        public string Color { get; set; } = "blue";
        public Square StartSquare;
        public Square WinSquare;
        public List<Piece> Pieces { get; set; } = new();
    }

    public class RedPlayer : IPlayer
    {
        public string Color { get;  set; } = "red";
        public Square StartSquare;
        public Square WinSquare;
        public List<Piece> Pieces { get; set; } = new();
    }
    public class YellowPlayer : IPlayer
    {
        public string Color { get; set; } = "yellow";
        public Square StartSquare;
        public Square WinSquare;
        public List<Piece> Pieces { get; set; } = new();
    }

    public class GreenPlayer : IPlayer
    {
        public string Color { get; set; } = "green";
        public Square StartSquare;
        public Square WinSquare;
        public List<Piece> Pieces { get; set; } = new();
    }
}