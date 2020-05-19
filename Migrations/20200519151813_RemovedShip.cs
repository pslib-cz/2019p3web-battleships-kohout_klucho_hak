using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class RemovedShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "1d62c139-82f0-402b-b618-b444dcd6d503");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b64a9059-6ad2-4f4b-bf2a-eab2c4c7e352", "AQAAAAEAACcQAAAAEO8oamfXoUQYKOWd1A6YWeQAAsdur9nlzXS6oHzXjfk76Upj7kHSDEGU9rJMy8vTBw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88ffada8-ef5c-40d0-ac09-2ef227c01dab", "AQAAAAEAACcQAAAAEMUtEVCOzlbiSaJmOi1j+koC1F1apP7zozKOPFDeFQTOiw5bn6FJY9I+JVj4yYflYw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f7746ca-3ef0-4903-855b-05c1e0141454", "AQAAAAEAACcQAAAAEBGHiEamdPINxIWt9VzmOVkKNLl4sUlzmQqN8+QRFVtm4CxufLFiC6Eb84f6tF96nA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "badcc9d2-9457-4560-8554-291021c79fc1", "AQAAAAEAACcQAAAAEF0B9R9oB5m6GEiE5/mXiQ4JieKKyYiLAQk0U+KzWyjeWRzLiehlp2m1EXJ7dZmiOw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "efec7949-80d5-4630-acaa-8038ec246e16");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6fb5e28b-65d5-4d90-9fed-798c019a0126", "AQAAAAEAACcQAAAAEBavwBSKTxlQGqeBB5e9XPUa7jEcqAm8SCp0C1wjx0+IcgoEXqZWxEm8/eAdjqnVlQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e57a11ba-0177-428d-95bc-ebffa2112f4b", "AQAAAAEAACcQAAAAEDrkybCxgHpmuhWHK0DkQJMDd+EhSx3dStuazb9Pln8ViBqDN4tRI/wxwX2pUohYng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a02c6bc-3313-4b68-b173-d88ee580dc87", "AQAAAAEAACcQAAAAEDGqAU0nVY/7zp/E4DKXe7xiznidhoOGea0zStFUcgOFOpm//Ys/uH19Jewa9UUGbw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf1ad859-8142-472a-a664-d1bc1e2da9d8", "AQAAAAEAACcQAAAAEI4+3quIk7b6dYvfYVrHD6UV74m4wx4//FnoW12wi5BrwJt/ZhRCKEsXZV91Ol0iHA==" });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "IsAllowed", "Name" },
                values: new object[] { 12, true, "Aircraft carrier II" });

            migrationBuilder.InsertData(
                table: "ShipPieces",
                columns: new[] { "Id", "PieceState", "PosX", "PosY", "ShipId" },
                values: new object[,]
                {
                    { 188, 0, 0, 0, 12 },
                    { 217, 4, 6, 1, 12 },
                    { 216, 0, 6, 0, 12 },
                    { 215, 4, 5, 3, 12 },
                    { 214, 1, 5, 2, 12 },
                    { 213, 1, 5, 1, 12 },
                    { 212, 4, 5, 0, 12 },
                    { 211, 4, 4, 3, 12 },
                    { 210, 1, 4, 2, 12 },
                    { 209, 1, 4, 1, 12 },
                    { 208, 4, 4, 0, 12 },
                    { 207, 4, 3, 3, 12 },
                    { 206, 1, 3, 2, 12 },
                    { 205, 4, 3, 1, 12 },
                    { 204, 0, 3, 0, 12 },
                    { 203, 4, 2, 3, 12 },
                    { 202, 1, 2, 2, 12 },
                    { 201, 4, 2, 1, 12 },
                    { 200, 0, 2, 0, 12 },
                    { 199, 4, 2, 3, 12 },
                    { 198, 1, 2, 2, 12 },
                    { 197, 4, 2, 1, 12 },
                    { 196, 0, 2, 0, 12 },
                    { 195, 4, 1, 3, 12 },
                    { 194, 1, 1, 2, 12 },
                    { 193, 4, 1, 1, 12 },
                    { 192, 0, 1, 0, 12 },
                    { 191, 0, 0, 3, 12 },
                    { 190, 4, 0, 2, 12 },
                    { 189, 0, 0, 1, 12 },
                    { 218, 4, 6, 2, 12 },
                    { 219, 0, 6, 3, 12 }
                });
        }
    }
}
