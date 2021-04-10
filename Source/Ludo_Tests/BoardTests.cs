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
        public void SquaresAreCreated()
           
        {
            var Board = new Board();
            Assert.Equal(40, Board.Squares.Count);
        }

        [Fact]
        public void NestIsCreated()
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

        [Fact]
        public void WinSquaresAreCreated()
        {
            Game game = new();
            game.SetUpBoard(2, false);

            int? playerWinSquare = game.Players[0].WinSquare.SquareId;

            Assert.True(playerWinSquare != null);
        }

        //om du inte kastar 1 eller 6 och bara en lever, flytta direkt
        [Fact]
        public void FirstRollIsAutomatic()
        {
            Game game = new Game();
            game.SetUpBoard(2, false);
            IPlayer player = game.Players[0];
            Piece piece = game.SelectPiece(player, 6);

            Assert.Equal(typeof(Piece), piece.GetType());
        }

        //om du INTE kastar 1, 6 och alla pj�ser �r d�da, flytta inte
        [Fact]
        public void IfAllPiecesAreDeadAndRoll4Dontmove()
        {
            Game game = new Game();
            game.SetUpBoard(2, false);
            IPlayer player = game.Players[0];
            Piece piece = game.SelectPiece(player, 4);

            Assert.Null(piece);
        }
    }
}