using Microsoft.EntityFrameworkCore.Migrations;

namespace Ludo_Game_Console.Migrations
{
    public partial class Initialludo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaveGame",
                columns: table => new
                {
                    SaveGameId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveGame", x => x.SaveGameId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    StartSquareNr = table.Column<int>(type: "INTEGER", nullable: false),
                    SaveGameId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_SaveGame_SaveGameId",
                        column: x => x.SaveGameId,
                        principalTable: "SaveGame",
                        principalColumn: "SaveGameId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pieces",
                columns: table => new
                {
                    PieceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsAlive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentSquareNr = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    Steps = table.Column<int>(type: "INTEGER", nullable: false),
                    PieceNr = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pieces", x => x.PieceId);
                    table.ForeignKey(
                        name: "FK_Pieces_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pieces_PlayerId",
                table: "Pieces",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SaveGameId",
                table: "Players",
                column: "SaveGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pieces");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "SaveGame");
        }
    }
}
