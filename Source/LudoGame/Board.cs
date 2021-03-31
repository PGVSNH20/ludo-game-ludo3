using System.Collections.Generic;

namespace LudoGame
{
    public class Board
    {
        public static void MakeSquares()
        {
            List<Square> SquareList = new List<Square>();
            for (var i = 0; i < 40; i++)
            {
                SquareList.Add(new Square(i));
            }
        }
    }
}
