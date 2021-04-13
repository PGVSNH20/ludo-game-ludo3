using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace LudoGame
{
    //databas
    //package manager console
    //Add-Migration "Initial ludo"
    //Update-database
    public class LudoContext : DbContext
    {
        public DbSet<SaveGame> SaveGame { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Piece> Pieces { get; set; }

        //fixa path
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path, "savegame.db");
            optionsBuilder.UseSqlite(@$"Data Source={filename}");
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