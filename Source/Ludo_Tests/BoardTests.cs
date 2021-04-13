using LudoGame;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ludo_Tests
{
    // Skapa br�de med r�tt antal rutor
    // Fr�ga efter antal spelare
    // Spelare v�ljer f�rg
    // Skapa startruta f�r varje f�rg
    // Sl� t�rning, random �r f�rst, eller r�d
    // bara till�tet med 1 eller 6 p� f�rsta draget XXX
    // ruta sparar vem som st�r d�r
    // om en till kliver p� ruta kastar ruta ut den f�rsta

    //arrange
    //act
    //assert
    public class BoardTests
    {
        [Fact]
        public void SquaresAreCreated()

        {
            var Board = new Board();
            Assert.Equal(40, Board.Squares.Count);
        }

        [Fact]
        public void NestIsCreatedUnique()
        {
            Game Game = new();
            Game.SetUpBoard(3, false);
            var playersStartSquare = Game.Players[0].Pieces[0].CurrentSquare;
            var playersStartSquare2 = Game.Players[1].Pieces[0].CurrentSquare;
            var playersStartSquare3 = Game.Players[2].Pieces[0].CurrentSquare;

            Assert.Equal(typeof(Nest), playersStartSquare.GetType());
            Assert.Equal(typeof(Nest), playersStartSquare2.GetType());
            Assert.Equal(typeof(Nest), playersStartSquare3.GetType());
        }

        [Fact]
        public void CanSaveAndLoadFromDb()
        {
            LudoContext db = new();

            Game game = new();
            game.SetUpBoard(2, false);

            var testPieceOne = game.Players[0].Pieces[0];
            var testPieceTwo = game.Players[1].Pieces[0];

            //f�rsta spelaren sl�r 6
            game.MoveToSquare(testPieceOne, 6);
            //andra spelaren sl�r 1
            game.MoveToSquare(testPieceTwo, 1);
            //f�rsta spelaren sl�r 4
            game.MoveToSquare(testPieceOne, 4);
            //andra spelaren sl�r 3
            game.MoveToSquare(testPieceTwo, 3);

            db.Database.EnsureCreated();
            SaveGame save = new();
            save.SaveGameId = 100;
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
            List<Player> playerlist = new();
            var loadplayer = db.Players.Where(player => player.SaveGameId == save.SaveGameId);
            foreach (var load in loadplayer)
            {
                var pieces = db.Pieces.Where(piece => piece.Color == load.Color).ToList();
                foreach (var piece in pieces)
                {
                    load.Pieces.Add(piece);
                }
                playerlist.Add(load);
            }

            int expected = 9;
            var actual = playerlist[0].Pieces[0].CurrentSquareNr;

            Assert.Equal(expected, actual);
            var players = db.Players.Where(player => player.SaveGameId == save.SaveGameId);
            foreach (var player in players)
            {
                var pieces = db.Pieces.Where(piece => piece.PlayerId == player.PlayerId);
                foreach (var piece in pieces)
                {
                    db.Pieces.Remove(piece);
                }
                db.Players.Remove(player);
            }
            db.SaveGame.Remove(save);
            db.SaveChanges();
        }
    }
}