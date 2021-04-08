using LudoGame;
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

        [Fact]
        public static void SquaresAreCreated()
           
        {
            var Board = new Board();
            Assert.Equal(40, Board.Squares.Count);
        }

        //[Fact]
        //public static void NestIsCreated()
        //{
        //    var Game = new Game();
        //    Game.SelectNumberOfPlayers(3);
        //    var playersStartSquare = Game.Players[0].Pieces[0].CurrentSquare.SquareId;
        //    var playersStartSquare2 = Game.Players[1].Pieces[1].CurrentSquare.SquareId;
        //    var playersStartSquare3 = Game.Players[2].Pieces[2].CurrentSquare.SquareId;

        //    Assert.Equal(0, playersStartSquare);
        //    Assert.Equal(10, playersStartSquare2);
        //    Assert.Equal(20, playersStartSquare3);
        //}
    }
}