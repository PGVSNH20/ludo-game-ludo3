using LudoGame;
using Xunit;
using System.Linq;
namespace Ludo_Tests
{
    public class GameTests
    {
        [Fact]
        public void CanMovePiece()
        {
            Game game = new();
            game.SetUpBoard(2, false);
            var square = game.Board.Squares.Single(square => square.SquareId == 10);

            Piece piece = new()
            {
                IsAlive = true,
                Color = "red",
                CurrentSquare = square
            };

            game.MoveToSquare(piece, 5);

            Assert.Equal(15, piece.CurrentSquare.SquareId);
        }

        [Fact]
        public void CanMoveFromNestRoll1()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[0];

            Game.MakePieces(player);

            Piece piece = game.SelectPiece(player, 1);

            game.MoveToSquare(piece, 1);

            Assert.Equal(1, player.Pieces[0].CurrentSquare.SquareId);
        }

        [Fact]
        public void NotAbleToMoveFromNestRoll2()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[0];

            Game.MakePieces(player);

            Piece piece = game.SelectPiece(player, 2);

            Assert.Null(piece);
        }

        [Fact]
        public void FindWinSquareId()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[0];

            Game.MakePieces(player);

            Piece testpiece = player.Pieces[0];
            game.SetUpWinSquares(testpiece, 3);

            int expected = 3;
            int actual = testpiece.CurrentSquare.SquareId;
            //51 '3'
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void CanSelectPiece()
        {
            Game game = new();
            game.SetUpBoard(1, false);
            IPlayer player = game.Players[0];

            Game.MakePieces(player);
            var piece = game.SelectPiece(player, 1);

            Assert.Equal(typeof(Piece), piece.GetType());
        }

        [Fact]
        public void CanKnuff()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer playerone = game.Players[0];
            IPlayer playertwo = game.Players[1];

            Piece testpieceone = playerone.Pieces[0];
            Piece testpiecetwo = playertwo.Pieces[1];

            //spelare 1 till ruta 12
            game.MoveToSquare(testpieceone, 6);
            game.MoveToSquare(testpieceone, 6);
            //spelare 2 till ruta 12
            game.MoveToSquare(testpiecetwo, 2);

            Assert.False(testpieceone.IsAlive);
        }

        [Fact]
        public void CantKnuffOwnPiece()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer playerone = game.Players[0];

            Piece testpieceone = playerone.Pieces[0];
            Piece testpiecetwo = playerone.Pieces[1];

            game.MoveToSquare(testpieceone, 6);
            game.MoveToSquare(testpiecetwo, 6);

            Assert.True(testpieceone.IsAlive);
        }

        [Fact]
        public void MovesBackToNestWhenKnuffd()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer playerone = game.Players[0];
            IPlayer playertwo = game.Players[1];

            Piece testpieceone = playerone.Pieces[0];
            Piece testpiecetwo = playertwo.Pieces[1];
            //spelare 1 till ruta 12
            game.MoveToSquare(testpieceone, 6);
            game.MoveToSquare(testpieceone, 6);
            //spelare 2 till ruta 12
            game.MoveToSquare(testpiecetwo, 2);

            Assert.Equal(0, testpieceone.CurrentSquare.SquareId);
        }
    }
}