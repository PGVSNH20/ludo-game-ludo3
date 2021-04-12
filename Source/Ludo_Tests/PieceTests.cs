using LudoGame;
using Xunit;

namespace Ludo_Tests
{
    public class PieceTests
    {

        [Fact]
        public void PiecesAreCreated()
        {
            RedPlayer redplayer = new();
            Game.MakePieces(redplayer);
            Assert.Equal(typeof(Piece), redplayer.Pieces[0].GetType());
        }

        [Fact]
        public void RightNumberOfPieces()
        {
            RedPlayer redplayer = new();
            Game.MakePieces(redplayer);
            var pieces = redplayer.Pieces;

            Assert.Equal(4, pieces.Count);
        }

        [Fact]
        public void PiecesHaveCorrectColor()
        {
            RedPlayer redplayer = new();
            Game.MakePieces(redplayer);
            var pieces = redplayer.Pieces;

            Assert.Equal("red", pieces[0].Color);
        }
    }
}