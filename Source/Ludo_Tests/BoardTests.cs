using LudoGame;
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

        [Fact]
        public void SquaresAreCreated()
           
        {
            var Board = new Board();
            Assert.Equal(40, Board.Squares.Count);
        }

        [Fact]
        public void NestIsCreatedUnique()
        {
            Game Game = new Game();
            Game.SetUpBoard(3, false);
            int playersStartSquare = Game.Players[0].Pieces[0].CurrentSquare.SquareId;
            int playersStartSquare2 = Game.Players[1].Pieces[0].CurrentSquare.SquareId;
            int playersStartSquare3 = Game.Players[2].Pieces[0].CurrentSquare.SquareId;

            Assert.Equal(0, playersStartSquare);
            Assert.Equal(10, playersStartSquare2);
            Assert.Equal(20, playersStartSquare3);
        }

        //[Fact]
        //public void WinSquaresAreCreated()
        //{
        //    Game game = new();
        //    game.SetUpBoard(2, false);

        //    Assert.NotNull(playerWinSquare);
        //}
    }
}