using LudoGame;
using System.Linq;
using Xunit;

namespace Ludo_Tests
{
    public class PlayerTests
    {
        [Fact]
        public void NumberOfPlayersCorrect()
        {
            var Game = new Game();
            Assert.Equal(2, Game.Players.Count);
        }

        [Fact]
        public void ColorIsCorrect()
        {
            var Game = new Game();
            //skapa två spelare
            Game.SelectNumberOfPlayers(2);
            //rätt antal spelare
            Assert.Equal(2, Game.Players.Count);
            //rätt färg
            var player = Game.Players[0];
            Assert.Equal("red", player.Color);
        }
    }
}