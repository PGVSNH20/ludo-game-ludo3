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
            EventLoop gamePlay = new EventLoop();
            gamePlay.RunGame();
        }

    }
}