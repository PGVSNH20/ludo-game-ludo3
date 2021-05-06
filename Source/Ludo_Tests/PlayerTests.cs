using LudoGame;
using Xunit;

namespace Ludo_Tests
{
    public class PlayerTests
    {
        [Fact]
        public void NumberOfPlayersCorrect()
        {
            var Game = new Game();
            Game.SetUpBoard(2, false);
            Assert.Equal(2, Game.Players.Count);
        }

        [Fact]
        public void ColorIsCorrect()
        {
            var Game = new Game();
            //skapa två spelare
            Game.SetUpBoard(2, false);
            //rätt antal spelare
            Assert.Equal(2, Game.Players.Count);
            //rätt färg
            var player = Game.Players[0];
            Assert.Equal("red", player.Color);
        }
    }
}