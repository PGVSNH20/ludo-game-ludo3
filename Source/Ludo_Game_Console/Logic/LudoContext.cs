using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LudoGame
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

        //C:\Users\Default\Documents
        //todo: fixa path
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=X:\savegame.db");
        }
    }

    public class Player
    {
        public int PlayerId { get; set; }
        public List<Piece> Pieces { get; set; } = new();
        public string Color { get; set; }
        public int StartSquareNr { get; set; }
        public int SaveGameId { get; set; }
    }

    public class SaveGame
    {
        public int SaveGameId { get; set; }
        public List<Player> Players { get; set; } = new();
    }
}