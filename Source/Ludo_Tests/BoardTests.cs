using FluentAssertions;
using LudoGame;
using System.Collections.Generic;
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

    // använder fluent assertations: https://fluentassertions.com/introduction
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