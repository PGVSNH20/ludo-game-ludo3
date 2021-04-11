using LudoGame;
using Xunit;

namespace Ludo_Tests
{
    public class WinSquareTests
    {
        [Fact]
        public void OnSquare3roll5()
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
        public void OnSquare2roll4()
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
        public void OnSquare1roll6()
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
        public void OnSquare4roll5()
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
    }
}
