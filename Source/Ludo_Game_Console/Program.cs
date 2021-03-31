using LudoGame;
using System;

namespace Ludo_Game_Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //testscenario, bara ett drag var
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

    internal class Game
    {
        public static void StartGame()
        {
            //skapar rutor
            Board.MakeSquares();
            //spelare skapas och de väljer färg
            var Players = Board.MakePlayers();
            //varje spelare väljer en pjäs (?) och gör ett drag var
            for (var i = 0; i < Players.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Player {i + 1} ({Players[i].Color}), select a piece: ");
                Piece currentPiece = Players[i].SelectPiece();
                int diceroll = Dice.RollDice();
                Board.MoveTo(diceroll, currentPiece);
            }
        }
    }
}