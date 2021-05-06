using System;

namespace LudoGame
{
    public class Dice
    {
        //rulla tärning på enter
        public static int RollDice(IPlayer player)
        {
            Console.WriteLine($"It's {player.Color}'s turn. Press enter to roll the dice");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            return DiceRoll();
        }

        //rulla tärning
        public static int DiceRoll()
        {
            Random rand = new();
            int diceroll = rand.Next(1, 6);
            Console.WriteLine($"You rolled a {diceroll}");
            return diceroll;
        }
    }
}