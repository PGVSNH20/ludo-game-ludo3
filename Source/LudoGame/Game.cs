using System;

namespace LudoGame
{
    public class Game
    {
        public static int NumberOfPlayers { get; set; }
        public static void SelectNumberOfPlayers(string input)
        {
            NumberOfPlayers = Int32.Parse(input);
        }
    }
}
