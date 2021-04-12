using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Game_Console
{
    public class Database
    {
        public void GameMenu()
        {
            Console.WriteLine("");
        }

        public void Save()
        {
            LudoContext db = new();
            db.Database.EnsureCreated();

        }

        public void Load()
        {

        }
    }
}
