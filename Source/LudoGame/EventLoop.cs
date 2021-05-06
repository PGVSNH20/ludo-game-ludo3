using System;
using System.Linq;

namespace LudoGame
{
    //varje spelare:
    //väljer färg
    //välja namn
    //pjäser skapas
    //spelbrädet skapas (square)
    //skapa bo
    //knuffa pjäser
    //spelare slår tärning
    //spelare väljer pjäs, inte på första draget
    //om man inte rullar 1, 6 och alla pjäser är döda så får man inte välja en pjäs ..
    //automatiskt flytta levande pjäs om endast en lever
    //om en spelare har möjlighet att knuffa ut en annan spelares pjäs vill detta visas.
    //vinst streckan 
    //flytta tillbaka pjäs till start om den blir knuffad
    //felhantera user input om t.ex enter
    //kliva över 40 går runt, tillbak på 0

    public class EventLoop
    {

        public static void GameLoop()
        {
            Game game = CreateGame();
            //ett drag var tills någon spelare inte har pjäser kvar
            while (!game.Players.Any(player => player.Pieces.Count == 0))
            {
                RunGameMove(game);
            }
            IPlayer winner = game.Players.SingleOrDefault(player => player.Pieces.Count == 0);
            Console.WriteLine($"{winner.Color} is the winner !!!");
        }

        public static void RunGameMove(Game game)
        {
            foreach (IPlayer player in game.Players)
            {
                Console.Clear();
                //rulla tärning
                int diceroll = Dice.RollDice(player);
                //välja pjäs
                Piece piece = game.SelectPiece(player, diceroll);


                if (piece != null)
                {
                    int newsquarenr = piece.Steps + diceroll;

                    //stanna på yttre raden om du rullar mindre än 40
                    if (newsquarenr < 40)
                    {
                        //spara gamla rutan för att skriva drag
                        ISquare oldsquare = piece.CurrentSquare;
                        //flytta pjäs
                        game.MoveToSquare(piece, diceroll);
                        //skriv ut vad som hände
                        bool isNest = oldsquare.GetType() == typeof(Nest);
                        if (isNest) Console.WriteLine($"Piece nr {piece.PieceNr} has moved from nest to square nr {piece.CurrentSquare.SquareId}");
                        else Console.WriteLine($"Piece nr {piece.PieceNr} has moved from square nr {oldsquare.SquareId} to square nr {piece.CurrentSquare.SquareId}");
                    } else  //om någon pjäs tagit mer än 40 steg, gå in i vinststräckan

                    {
                        //gå till inre raden
                        if (player.WinSquares != null)
                        {
                            //spara gamla rutan för att skriva drag
                            ISquare oldsquare = piece.CurrentSquare;
                            //flytta pjäs
                            game.WinRowMove(piece, diceroll);
                            //skriv ut vad som hände om pjäsen inte vunnit
                            if (player.Pieces.Contains(piece))
                            {
                                Console.WriteLine($"Piece nr {piece.PieceNr} has moved from square nr {oldsquare.SquareId} to square nr {piece.CurrentSquare.SquareId}");
                                Console.WriteLine($"Piece nr {piece.PieceNr} is {5 - piece.CurrentSquare.SquareId} steps from winning");
                            }
                        } else
                        {
                            //skapa inre raden om den inte finns
                            int steps = newsquarenr - 40;
                            game.SetUpWinSquares(piece, steps);
                        }
                    }
                }
                Console.ReadLine();
            }
        }

        public static Game CreateGame()
        {
            Game game = new();
            //fråga om antal spelare
            Console.WriteLine("Welcome!");
            Console.WriteLine("Do you want to:\n1. Create a new game\n2. Load saved game");
            int nr = 0;
            bool boolinput = Int32.TryParse(Console.ReadLine(), out nr);
            while (!boolinput && nr != 1 && nr != 2)
            {
                Console.WriteLine("Input 1 or 2");
                boolinput = Int32.TryParse(Console.ReadLine(), out nr);
            }
            if (nr == 1)
            {
                return CreateNewGame(game);
            } else
            {
                return game;

            }
        }

        public static Game CreateNewGame(Game game)
        {
            Console.WriteLine("Select number of players (2 - 4)");
            string input = Console.ReadLine();
            //vägrar acceptera annat än 2,3,4
            while (input != "1" && input != "2" && input != "3" && input != "4")
            {
                input = Console.ReadLine();
            }
            int number = Int32.Parse(input);

            //fråga om man vill välja färg själv
            Console.WriteLine("Do you want to select your own colors? (y/n)");
            char colorinput = yesOrNo();


            //skapa bräde med antal spelare, automatisk färg
            if (colorinput == 'n') game.SetUpBoard(number, false);

            //skapa bräde med antal spelare, välj färg själv
            else if (colorinput == 'y') game.SetUpBoard(number, true);

            //returnera bräde
            return game;
        }

        public static char yesOrNo()
        {
            char colorinput = Console.ReadKey().KeyChar;
            while (colorinput != 'y' && colorinput != 'n')
            {
                colorinput = Console.ReadKey().KeyChar;
            }
            return colorinput;
        }
    }
}