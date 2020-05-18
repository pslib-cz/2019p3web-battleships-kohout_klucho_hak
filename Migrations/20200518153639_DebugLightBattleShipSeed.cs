using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class DebugLightBattleShipSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "c8e924e8-d873-4e25-8038-ea67e650f8ca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "068ffd8c-0e77-45aa-a877-612cf127a181", "AQAAAAEAACcQAAAAEDfV1bsFpJfKfU76Pa3WsJCB/9ZfVRTXbk6QSDbtYgj0rC5be6hD5vVIf3Z+VT6FUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7cb327de-827f-4cdb-af71-4b92d12f6985", "AQAAAAEAACcQAAAAEMIb51rdGHvac2+623TjOd25fpV+mXJa1pzszTagWHtzYZlP910uCqmJJu7lzM6aDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d776c0b5-e980-4002-b1d7-af8ade4cba6b", "AQAAAAEAACcQAAAAEE2gdpSUaASL4y/xDKbXJWUBor1ixya3gDS+n0zVUEGuF5Tiqu+P61Rvld/ngM/MJA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2110164-4238-4d12-92d2-7eb1e7626e0d", "AQAAAAEAACcQAAAAEHn1CLyzZNZVix+EMNvKUl5xI+ihCvRFY7vpvuQ4N4tuT32/7mBzq7iK0yuFaMu3iw==" });

            migrationBuilder.UpdateData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 186,
                column: "PieceState",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "8ec5ed8c-3f2e-48fc-a07e-7d137a32053a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "695f98f1-b6d3-4e07-8406-ef61e8f5bd16", "AQAAAAEAACcQAAAAENiUyOgbBTPw3r4Nu2SVPdwKbPeezrse30QVm/0xPJFm1nS7UuB9ZCCExQOIejuHRg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "235e4d9a-cd94-48ff-8109-be37d5f4e9ed", "AQAAAAEAACcQAAAAEH8jVctqMMIV8EEpb5n/TnIu19lbY530vAc18qTn/w6VVVyaoC2MapcK2QXsKOURjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c04323c-61e8-44a6-b7e8-0371c621c1db", "AQAAAAEAACcQAAAAEOhk/9xtTDm5HV2R6123A4YKqqH+70V5FVoWHBhytaCtyhPdhaP6BrivbAcm7z8EbA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ba5f7a6-518c-4803-a7d3-9a7c543d5a85", "AQAAAAEAACcQAAAAENcAQNmfbeku5qji9buWT2DAt/WuOLLX6HkvdoMt7YlPEIndsOqqt0ZOlug1osbk3Q==" });

            migrationBuilder.UpdateData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 186,
                column: "PieceState",
                value: 4);
        }
    }
}
