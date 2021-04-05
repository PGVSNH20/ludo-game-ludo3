﻿using System;

namespace LudoGame
{
    public class Dice
    {
        //rulla tärning på enter
        public static int RollDice()
        {
            Console.WriteLine("Press enter to roll the dice");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            return DiceRoll();
        }

        //rulla tärning
        public static int DiceRoll()
        {
            Random rand = new();
            int diceroll = rand.Next(0, 6);
            Console.WriteLine("You rolled a {0}", diceroll);
            return diceroll;
        }
    }
}