using LudoGame;
using Xunit;

namespace Ludo_Tests
{
    public class PlayerTests
    {
        [Fact]
        public void NumberOfPlayersCorrect()
        {
            Game.SelectNumberOfPlayers("2");
            Assert.Equal(2, Game.NumberOfPlayers);
        }
    }
}