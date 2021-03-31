using LudoGame;
using System;
using System.Collections.Generic;

namespace Ludo_Game_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.StartGame();
        }
    }

    // Skapa bräde med rätt antal rutor
    // Fråga efter antal spelare
    // Spelare väljer färg
    // Skapa startruta för varje färg
    // Slå tärning, random är först, eller röd
    // bara tillåtet med 1 eller 6 på första draget
    // ruta sparar vem som står där
    // om en till kliver på ruta kastar ruta ut den första

    class Game
    {
        public static void StartGame()
        {
            Board.MakeSquares();
            StartLudo.MakePlayers();
            StartLudo.ChooseColor();
        }
    }
}
