using System;
using System.Collections.Generic;
using System.Linq;

namespace LudoGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = StartGame();
            var savegame = EventLoop.GameLoop(game);
            if (savegame != null) 
            {
                List<string> games = new();
                LudoContext db = new();
                foreach (var save in db.SaveGame)
                {
                    games.Add(save.SaveGameName);
                }
                while (games.Contains(savegame.GameId)) 
                {
                    Console.WriteLine("Name already exists");
                    savegame = EventLoop.AskForSave(savegame); 
                }
                Database.Save(savegame);
            }
            Console.WriteLine("Do you want to continue (y/n)?");
            char input = EventLoop.YesOrNo();
            if ( input == 'y') EventLoop.GameLoop(game);

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
                List<string> games = new();

                foreach (var savegame in db.SaveGame)
                {
                    games.Add(savegame.SaveGameName);
                    Console.WriteLine(savegame.SaveGameName);
                }

                string name = Console.ReadLine();
                while (!games.Contains(name))
                {
                    Console.WriteLine("input a valid savegame");
                    name = Console.ReadLine();
                }

                var gameid = db.SaveGame.SingleOrDefault(save => save.SaveGameName == name);
                if (gameid != null) return Database.Load(gameid.SaveGameId);
                else return null;
            }
        }
    }
}