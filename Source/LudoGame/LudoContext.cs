using LudoGame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Game_Console
{
    //todo: databas
    //package manager console
    //Add-Migration "Initial ludo"
    //Update-database
    public class LudoContext : DbContext
    {
        public DbSet<SaveGame> SaveGame { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=./savegameggasdfds.db");
        }
    }

    public class Player
    {
        public int PlayerId { get; set; }
        public List<Piece> Pieces { get; set; } = new();
        public string Color { get; set; }
    }

    public class SaveGame
    {
        public int SaveGameId { get; set; }
        public List<Player> Players { get; set; } = new();
    }
}
