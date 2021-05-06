﻿using System.Collections.Generic;

namespace LudoGame
{
    public class Board
    {
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