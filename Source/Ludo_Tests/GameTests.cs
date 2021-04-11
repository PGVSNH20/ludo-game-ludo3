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
                isAlive = true,
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

            game.MakePieces(player);

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

            game.MakePieces(player);

            Piece piece = game.SelectPiece(player, 2);

            Assert.Null(piece);
        }

        [Fact]
        public void FindWinSquareId()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[0];

            game.MakePieces(player);

            Piece testpiece = player.Pieces[0];
            game.SetUpWinSquares(testpiece, 3);

            int expected = 3;
            int actual = testpiece.CurrentSquare.SquareId;
            //51 '3'
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void onSquare3roll5()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[1];

            game.MakePieces(player);
            Piece testpiece1 = player.Pieces[1];

            //står på ruta 3
            game.SetUpWinSquares(testpiece1, 3);
            //rullar en femma
            game.WinRowMove(testpiece1, 5);

            Assert.Equal(2, testpiece1.CurrentSquare.SquareId);
        }

        [Fact]
        public void onSquare2roll4()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[1];

            game.MakePieces(player);
            Piece testpiece1 = player.Pieces[1];

            //står på ruta 2
            game.SetUpWinSquares(testpiece1, 2);
            //rullar 4
            game.WinRowMove(testpiece1, 4);

            Assert.Equal(4, testpiece1.CurrentSquare.SquareId);
        }

        [Fact]
        public void onSquare1roll6()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[1];

            game.MakePieces(player);
            Piece testpiece1 = player.Pieces[1];

            //står på ruta 1
            game.SetUpWinSquares(testpiece1, 1);
            //rullar 6
            game.WinRowMove(testpiece1, 6);

            Assert.Equal(3, testpiece1.CurrentSquare.SquareId);
        }

        [Fact]
        public void onSquare4roll5()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[1];

            game.MakePieces(player);
            Piece testpiece1 = player.Pieces[1];

            //står på ruta 4
            game.SetUpWinSquares(testpiece1, 4);
            //rullar 5
            game.WinRowMove(testpiece1, 5);

            Assert.Equal(1, testpiece1.CurrentSquare.SquareId);
        }

        [Fact]
        public void MovesBackOnWinSquare()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            IPlayer player = game.Players[1];

            game.MakePieces(player);
            Piece testpiece1 = player.Pieces[1];
            Piece testpiece2 = player.Pieces[2];
            Piece testpiece3 = player.Pieces[3];
            Piece testpiece4 = player.Pieces[4];

            //står på ruta 3
            game.SetUpWinSquares(testpiece1, 3);
            //rullar en femma
            game.WinRowMove(testpiece1, 5);

            //står på ruta 2
            game.SetUpWinSquares(testpiece2, 2);
            //rullar 4
            game.WinRowMove(testpiece1, 5);

            //står på ruta 1
            game.SetUpWinSquares(testpiece3, 1);
            //rullar 6
            game.WinRowMove(testpiece1, 5);

            //står på ruta 4
            game.SetUpWinSquares(testpiece4, 4);
            //rullar 5
            game.WinRowMove(testpiece1, 5);

            Assert.Equal(2, testpiece1.CurrentSquare.SquareId);
            Assert.Equal(4, testpiece2.CurrentSquare.SquareId);
            Assert.Equal(3, testpiece3.CurrentSquare.SquareId);
            Assert.Equal(1, testpiece4.CurrentSquare.SquareId);
        }

        //[Fact]
        //public void CanSelectPiece()
        //{
        //    Game game = new();
        //    IPlayer redplayer = new RedPlayer();

        //    game.MakePieces(redplayer);
        //    var piece = game.SelectPiece(redplayer);

        //    Assert.Equal(typeof(Piece), piece.GetType());
        //}
    }
}