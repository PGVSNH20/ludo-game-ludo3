using System;
using System.Collections.Generic;

namespace LudoGame
{
    public class Player
    {
        public string Color { get; set; }
        public string Name { get; }
        public Square StartSquare;
        public Square WinSquare;
        
        //varje spelare:
        //todo: väljer färg
        //todo: välja namn

        //todo: spelbrädet skapas (square)
        //todo: pjäser skapas

        //todo: spelare slår tärning
        //todo: spelare väljer pjäs, inte på första draget
    }


    public class BluePlayer
    {
        public string color = "blue";
        public Square startSquare;
        public Square endSquare;
        public List<Piece> Pieces = new();
    }

    public class RedPlayer
    {

        public string color = "red";
        public Square startSquare;
        public Square endSquare;
        public List<Piece> Pieces = new();
    }
    public class YellowPlayer
    {
        public string color = "blue";
        public Square startSquare;
        public Square endSquare;
        public List<Piece> Pieces = new();
    }

    public class GreenPlayer
    {
        public string color = "blue";
        public Square startSquare;
        public Square endSquare;
        public List<Piece> Pieces = new();
    }
}