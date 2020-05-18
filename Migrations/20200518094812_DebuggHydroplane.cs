using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class DebuggHydroplane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 104,
                column: "PosX",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "5cf4f749-b354-4e05-bf9f-f82cdb045cf9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b474e5e6-0e82-4184-b9ec-e6f55689b6cf", "AQAAAAEAACcQAAAAEN2e36uDDe7BUJ4d/+sZ2aKB0O9zmer7YOHwYodbo8ZIaS9A6o4J6nv8PBvQ0HEpWQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67500a40-10e9-4529-a8a7-23de18a23a26", "AQAAAAEAACcQAAAAEIWIuvNm23E8gevIGAHkL69imQpnygJ5wVx3Uc+qhAMWXmOZhlCRM+PjEe3XRFLG8w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6c3745c-3932-4a30-b8fa-53f4ca4fe682", "AQAAAAEAACcQAAAAEKnH4EzJRxwILnRXrbsWMS9p1cFxjmyVg5DzPao11nbnl2WrNE9jvHzvLl9Yt/FapQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b36e7e5-38be-4b3f-a2b2-ca0b94911a84", "AQAAAAEAACcQAAAAEETKvoesmzg6val6R2UgOPp66reMYzXM3QLVKYxfBAaiCKbHmeOj7mClBi0/EtbkoA==" });

            migrationBuilder.UpdateData(
                table: "ShipPieces",
                keyColumn: "Id",
                keyValue: 104,
                column: "PosX",
                value: 0);
        }
    }
}
