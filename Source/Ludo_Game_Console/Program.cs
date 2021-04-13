using System;
using System.Collections.Generic;

namespace LudoGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = StartGame();
            var savegame = EventLoop.GameLoop(game);
            if (savegame != null) Database.Save(savegame);
        }

        public static Game StartGame()
        {
            Game game = new();
            //fråga om antal spelare
            Console.WriteLine("Welcome!");
            Console.WriteLine("Do you want to:\n1. Create a new game\n2. Load saved game");
            bool boolinput = Int32.TryParse(Console.ReadLine(), out int nr);
            while (!boolinput && nr != 1 && nr != 2)
            {
                Console.WriteLine("Input 1 or 2");
                boolinput = Int32.TryParse(Console.ReadLine(), out nr);
            }
            if (nr == 1)
            {
                return EventLoop.CreateNewGame(game);
            }
            else
            {
                //fråga vilken man laddar
                Console.WriteLine("Which game do you want to load?");
                LudoContext db = new();
                List<int> games = new();

                foreach (var savegame in db.SaveGame)
                {
                    games.Add(savegame.SaveGameId);
                    Console.WriteLine(savegame.SaveGameId);
                }

                bool loadinput = Int32.TryParse(Console.ReadLine(), out int id);
                while (!loadinput && !games.Contains(id))
                {
                    Console.WriteLine("input a valid savegame");
                    loadinput = Int32.TryParse(Console.ReadLine(), out id);
                }

                return Database.Load(id);
            }
        }
    }
}