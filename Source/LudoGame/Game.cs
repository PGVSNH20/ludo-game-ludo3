using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    //varje spelare:
    //väljer färg
    //välja namn

    //pjäser skapas
    //todo: spelbrädet skapas (square)
    //todo: skapa bo
    //todo: knuffa pjäser

    //todo: spelare slår tärning
    //todo: spelare väljer pjäs, inte på första draget
    //todo: vinst streckan 

    public class Game
    {
        public List<IPlayer> Players { get; set; } = new();
        public Board Board { get; set; }

        public void SelectNumberOfPlayers(int input) 
        {
            if (Board == null)
            {
                Board = new Board();
            }

            List<IPlayer> AvailablePlayers = new();

            AvailablePlayers.Add(new RedPlayer());
            AvailablePlayers.Add(new BluePlayer());
            AvailablePlayers.Add(new YellowPlayer());
            AvailablePlayers.Add(new GreenPlayer());


            for (int i = 0; i < input; i++)
            {
                IPlayer player = AvailablePlayers[i];
                Square square = Board.Squares.Single(square => square.SquareId == (i + (i * 9)));
                MakePieces(player, square);
                Players.Add(player);
            }
        }
        public void MakePieces(IPlayer player, Square square)
        {
            for (int i = 0; i < 4; i++)
            {
                Piece piece = new()
                {
                    isAlive = true,
                    Color = player.Color,
                    CurrentSquare = square
            };
            player.Pieces.Add(piece);
        }
    }
}
}