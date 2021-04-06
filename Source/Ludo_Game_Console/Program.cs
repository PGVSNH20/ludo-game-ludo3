using LudoGame;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ludo_Game_Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Select number of players:");
            string input = Console.ReadLine();
            Game.SelectNumberOfPlayers(input);
        }
    }
}