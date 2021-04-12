using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    public class Database
    {
        public void GameMenu()
        {
            Console.WriteLine("");
        }

        public static void Save(Game game)
        {
            LudoContext db = new();
            db.Database.EnsureCreated();
            SaveGame save = new();

            foreach (var player in game.Players)
            {
                Player newPlayer = new();
                newPlayer.Pieces = player.Pieces;
                newPlayer.Color = player.Color;
                newPlayer.StartSquareNr = (player.StartSquare.SquareId + 1);
                save.Players.Add(newPlayer);
                db.Players.Add(newPlayer);
                foreach (Piece piece in newPlayer.Pieces)
                {
                    db.Pieces.Add(piece);
                }
            }

            db.SaveGame.Add(save);
            db.SaveChanges();
        }

        public static Game Load(int gameid)
        {
            Game game = new();
            LudoContext db = new();
            SaveGame savegame = db.SaveGame.Find(gameid);
            Board board = new();
            game.Board = board;

            List<IPlayer> AvailablePlayers = new();

            AvailablePlayers.Add(new RedPlayer());
            AvailablePlayers.Add(new BluePlayer());
            AvailablePlayers.Add(new YellowPlayer());
            AvailablePlayers.Add(new GreenPlayer());

            List<IPlayer> Players = new();
            var players = db.Players.Where(player => player.SaveGameId == gameid);
            foreach (var player in players)
            {
                IPlayer newplayer = AvailablePlayers.SingleOrDefault(tplayer => tplayer.Color == player.Color);

                newplayer.Color = player.Color;
                var pieces = db.Pieces.Where(piece => piece.PlayerId == player.PlayerId);

                var nest = new Nest();
                newplayer.StartSquare = nest.CreateNest(player.StartSquareNr);

                foreach (var piece in pieces)
                {
                    if (piece.IsAlive)
                    {
                        Square square = board.Squares.SingleOrDefault(square => square.SquareId == piece.CurrentSquareNr);
                        square.SquarePiece = piece;
                        piece.CurrentSquare = square;
                    }
                    else
                    {
                        piece.CurrentSquare = newplayer.StartSquare;
                    }
                    newplayer.Pieces.Add(piece);
                }

                Players.Add(newplayer);
            }
            game.Players = Players;
            return game;
        }
    }
}