using FluentAssertions;
using LudoGame;
using Xunit;

namespace Ludo_Tests
{
    public class PieceTests
    {
        private static Square square = new(1);
        private Player Player = new("green", square);
        private Piece TestPiece { get; } = new Piece(true, square, "green");

        [Fact]
        public void PlayerCanCreatePiece()
        {
            Piece expected = TestPiece;

            Player.MakePieces();
            Piece actual = Player.Pieces[0];

            actual.Should().BeEquivalentTo(expected);
            actual.Color.Should().BeEquivalentTo("green");
            actual.CurrentSquare.SquareNr.Should().Be(1);

        }
    }
}