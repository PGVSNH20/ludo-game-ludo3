using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    public class Board
    {
        public string Nest { get; set; }
        public List<Square> Squares { get; set; }
        public Board()
        {
            Squares = new();
            for (int i = 0; i < 40; i++)
            {
                Square square = new();
                square.SquareId = i;
                Squares.Add(square);
            }
        }
    }
}