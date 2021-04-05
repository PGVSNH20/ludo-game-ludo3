using FluentAssertions;
using LudoGame;
using System.Collections.Generic;
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

    // anv�nder fluent assertations: https://fluentassertions.com/introduction
    public class BoardTests
    {
        private Board game = new();

        [Fact]
        public void SquaresAreCreatedAndUnique()
        {
            List<Square> actual = game.MakeSquares();
            actual.Should().HaveCount(count => count == 40).And.OnlyHaveUniqueItems();
        }

        [Fact]
        public void CanMoveToSquare()
        {
            List<Square> board = game.MakeSquares();
            Piece testpiece = new(true, board[20], "green");
            game.MoveTo(10, testpiece);

            int actual = testpiece.CurrentSquare.SquareNr;
            int expected = 30;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StartSquaresAreMade()
        {
            List<int> startSquareNr = new();
            game.MakeSquares();

            for (int i = 1; i <= 4; i++)
            {
                startSquareNr.Add(game.MakeStartSquare(i).SquareNr);
            }

            startSquareNr.Should().ContainInOrder(10, 20, 30, 40);
        }
    }
}