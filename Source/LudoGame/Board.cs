using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    public class Board
    {
        public string Nest { get; set; }
        public static List<Square> Squares { get; set; } = new();

        public Board()
        {
            for (int i = 0; i < 40; i++)
            {
                Square square = new();
                Squares.Add(square);
            }
        }
    }
}