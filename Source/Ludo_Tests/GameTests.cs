using Ludo_Game_Console;
using LudoGame;
using System.Linq;
using Xunit;

namespace Ludo_Tests
{
    public class GameTests
    {
        private Board game = new();

        [Fact]
        public void PlayersCanKnuff()
        {
            game.MakeSquares();
            var squareList = game.SquareList;

            Piece testpiece = new(true, squareList[29], "green");
            Piece testpiece2 = new(true, squareList[30], "green");
            squareList[30].Move(testpiece);

            Assert.False(testpiece2.isAlive);
        }

        [Fact]
        public void CanWinGame()
        {
            var board = game.MakeSquares();

            Piece testpiece = new(true, board[38], "green");
            Square winSquare = board.First(square => square.SquareNr == 40);
            winSquare.Move(testpiece);
            Assert.True(Game.CheckForWinCondition(board));
        }

        [Fact]
        public void StepsBackFromWinSquare()
        {
            game.MakeSquares();

            Piece testpiece = new(true, game.SquareList[38], "green");
            game.MoveTo(4, testpiece);

            int actual = testpiece.CurrentSquare.SquareNr;
            int expected = 38;

            Assert.Equal(expected, actual);
        }
    }
}