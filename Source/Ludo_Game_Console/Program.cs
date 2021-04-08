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
            int numberOfPlayers = Int32.Parse(input);
            var Game = new Game();
            Game.SelectNumberOfPlayers(numberOfPlayers);

            Console.WriteLine("Start Game!");
            


            //for (int i = 0; i < numberOfPlayers; i++)
            //{
            //    Console.WriteLine("Select a color: ");
            //    string colorInput = Console.ReadLine();
            //    Game.SelectColor(colorInput, i);
            //}
        }

    }
}