using Microsoft.EntityFrameworkCore.Migrations;

namespace Ludo_Game_Console.Migrations
{
    public partial class Piecefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_SaveGame_SaveGameId",
                table: "Pieces");

            migrationBuilder.DropIndex(
                name: "IX_Pieces_SaveGameId",
                table: "Pieces");

            migrationBuilder.DropColumn(
                name: "SaveGameId",
                table: "Pieces");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaveGameId",
                table: "Pieces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_SaveGameId",
                table: "Pieces",
                column: "SaveGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_SaveGame_SaveGameId",
                table: "Pieces",
                column: "SaveGameId",
                principalTable: "SaveGame",
                principalColumn: "SaveGameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
