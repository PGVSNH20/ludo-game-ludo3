using Microsoft.EntityFrameworkCore.Migrations;

namespace Ludo_Game_Console.Migrations
{
    public partial class Savegameupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SaveGameName",
                table: "SaveGame",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaveGameName",
                table: "SaveGame");
        }
    }
}
