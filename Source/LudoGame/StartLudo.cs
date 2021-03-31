using System;
using System.Collections.Generic;

namespace LudoGame
{
    public class StartLudo
    {
        public static string ChooseColor()
        {
            List<string> Colors = new List<string>() { "Red", "Green", "Yellow", "Blue" };
            string input = null;
            while (!Colors.Contains(input))
            {
                Console.WriteLine("Choose a color: ");
                foreach (var color in Colors)
                {
                    Console.WriteLine(color);
                }
                input = Console.ReadLine();
            }
            return input;
        }

        public static List<Player> MakePlayers()
        {
            List<Player> Players = new();

            //Hur många spelare?
            int numberOfPlayers = 0;
            Console.WriteLine("How many players?");
            while (numberOfPlayers != 2 || numberOfPlayers != 3 || numberOfPlayers != 4)
            {
                numberOfPlayers = Console.ReadKey().KeyChar;
            }

            //Varje spelare väljer färg
            for (var i = 0; i < numberOfPlayers; i++)
            {
                var color = ChooseColor();
                Player player = new Player(color);
                Players.Add(player);
            }

            return Players;
        }
    }
}
