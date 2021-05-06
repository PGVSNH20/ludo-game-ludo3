using Microsoft.EntityFrameworkCore.Migrations;

namespace Ludo_Game_Console.Migrations
{
    public partial class Loadupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Players_PlayerId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_SaveGame_SaveGameId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "SaveGameId",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Pieces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Players_PlayerId",
                table: "Pieces",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_SaveGame_SaveGameId",
                table: "Players",
                column: "SaveGameId",
                principalTable: "SaveGame",
                principalColumn: "SaveGameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pieces_Players_PlayerId",
                table: "Pieces");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_SaveGame_SaveGameId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "SaveGameId",
                table: "Players",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Pieces",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Pieces_Players_PlayerId",
                table: "Pieces",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_SaveGame_SaveGameId",
                table: "Players",
                column: "SaveGameId",
                principalTable: "SaveGame",
                principalColumn: "SaveGameId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
