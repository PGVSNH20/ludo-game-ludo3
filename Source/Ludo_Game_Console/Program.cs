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

    public class Game
    {
        public static void StartGame()
        {
            Board game = new();
            //skapar rutor
            game.MakeSquares();

            //Hur många spelare?
            Console.WriteLine("How many players? ( 2 - 4 )");
            int numberOfPlayers = 0;
            while (numberOfPlayers != 2 && numberOfPlayers != 3 && numberOfPlayers != 4)
            {
                numberOfPlayers = Int32.Parse(Console.ReadLine());
            }
            //spelare skapas och de väljer färg
            game.MakePlayers(numberOfPlayers);

            //spelare gör ett drag var tills nån har vunnit
            GameLoop(game);
        }

        public static void GameLoop(Board game)
        {
            while (!CheckForWinCondition(game.SquareList))
            {
                OneMoveEach(game);
            }
        }

        public static void OneMoveEach(Board game)
        {
            for (var i = 0; i < game.Players.Count; i++)
            {
                var currentPlayer = game.Players[i];

                Console.WriteLine($"Player {(i + 1)} ({currentPlayer.Color}), select a piece: ");

                //väljer en pjäs (?)
                var piece = currentPlayer.SelectPiece();

                //rullar tärning
                int diceroll = Dice.RollDice();

                //flyttar pjäs
                game.MoveTo(diceroll, piece);
            }
        }

        //om en pjäs står på sista rutan vinner den färgen
        public static bool CheckForWinCondition(List<Square> squares)
        {
            var board = squares.AsQueryable();
            var winSquare = board.First(square => square.SquareNr == 40);
            if (winSquare.Piece != null)
            {
                var winner = winSquare.Piece.Color;
                Console.WriteLine($"{winner} is the winner!!");
                return true;
            }
            return false;
        }
    }
}