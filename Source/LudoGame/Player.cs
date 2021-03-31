using System;
using System.Collections.Generic;

namespace LudoGame
{
    public class Player
    {
        public string Color { get; set; }
        public Square StartSquare;
        public List<Piece> Pieces = new();

        public Player(string color, Square startsquare)
        {
            Color = color;
            StartSquare = startsquare;
        }

        //Skapa 4 pjäser
        public void MakePieces()
        {
            for (var i = 0; i < 4; i++)
            {
                Pieces.Add(new Piece(true, StartSquare, Color));
            }
        }

        //Vilken pjäs flyttas? ska man välja det själv?
        public Piece SelectPiece()
        {
            //allt följande måste ändras
            int piecenr = 0;
            Console.WriteLine("1 | 2 | 3 | 4");
            //returnerar bara om en pjäs valts och den lever
            while (piecenr != 1 && piecenr != 2 && piecenr != 3 && piecenr != 4 && Pieces[piecenr].isAlive == true)
            {
                piecenr = Int32.Parse(Console.ReadLine());
            }
            return Pieces[piecenr - 1];
        }
    }
}