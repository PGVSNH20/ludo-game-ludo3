using LudoGame;
using Xunit;

namespace Ludo_Tests
{
    public class PieceTests
    {
        Square square = new();
        Board board = new();

        [Fact]
        public void PiecesAreCreated()
        {
            var Game = new Game();
            RedPlayer redplayer = new();
            Game.MakePieces(redplayer, square);
            Assert.Equal(typeof(Piece), redplayer.Pieces[0].GetType());
        }

        [Fact]
        public void RightNumberOfPieces()
        {
            var Game = new Game();
            RedPlayer redplayer = new();
            Game.MakePieces(redplayer, square);
            var pieces = redplayer.Pieces;

            Assert.Equal(4, pieces.Count);
        }

        [Fact]
        public void PiecesHaveCorrectColor()
        {
            var Game = new Game();
            RedPlayer redplayer = new();
            Game.MakePieces(redplayer, square);
            var pieces = redplayer.Pieces;

            Assert.Equal("red", pieces[0].Color);
        }
    }
}