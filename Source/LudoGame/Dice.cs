using System;

namespace LudoGame
{
    public class Dice
    {
        //rulla tärning på enter
        public static int RollDice()
        {
            Console.Clear();
            Random rand = new();
            Console.WriteLine("Press enter to roll the dice");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            int diceroll = rand.Next(0, 6);
            Console.WriteLine("You rolled a {0}", diceroll);
            return diceroll;
        }
    }
}