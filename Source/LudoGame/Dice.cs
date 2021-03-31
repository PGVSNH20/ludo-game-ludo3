using System;

namespace LudoGame
{
    public class Dice
    {
        public static int RollDice()
        {
            Random rand = new Random();
            int diceroll = rand.Next(0, 6);
            return diceroll;
        }
    }
}
