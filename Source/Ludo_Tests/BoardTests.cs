using LudoGame;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ludo_Tests
{
    // Skapa bräde med rätt antal rutor
    // Fråga efter antal spelare
    // Spelare väljer färg
    // Skapa startruta för varje färg
    // Slå tärning, random är först, eller röd
    // bara tillåtet med 1 eller 6 på första draget XXX
    // ruta sparar vem som står där
    // om en till kliver på ruta kastar ruta ut den första

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

            //första spelaren slår 6
            game.MoveToSquare(testPieceOne, 6);
            //andra spelaren slår 1
            game.MoveToSquare(testPieceTwo, 1);
            //första spelaren slår 4
            game.MoveToSquare(testPieceOne, 4);
            //andra spelaren slår 3
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