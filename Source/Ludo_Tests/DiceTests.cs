using LudoGame;
using Xunit;

namespace Ludo_Tests
{
    public class DiceTests
    {
        [Fact]
        public void CanRollDice()
        {
            int diceroll = Dice.DiceRoll();
            Assert.InRange(diceroll, 1, 6);
        }

        [Fact]
        public void DiceIsRandom()
        {
            int diceroll = Dice.DiceRoll();
            int diceroll2 = Dice.DiceRoll();

            Assert.NotEqual(diceroll, diceroll2);
        }
    }
}