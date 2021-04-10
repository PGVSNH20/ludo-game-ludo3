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