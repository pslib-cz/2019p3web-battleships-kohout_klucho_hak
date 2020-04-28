using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class ChangeForeignKeyToRightNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_AspNetUsers_UserId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserGames");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserGames",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_ApplicationUserId",
                table: "UserGames",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_AspNetUsers_ApplicationUserId",
                table: "UserGames",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGames_AspNetUsers_ApplicationUserId",
                table: "UserGames");

            migrationBuilder.DropIndex(
                name: "IX_UserGames_ApplicationUserId",
                table: "UserGames");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserGames");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserGames",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId",
                table: "UserGames",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGames_AspNetUsers_UserId",
                table: "UserGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
