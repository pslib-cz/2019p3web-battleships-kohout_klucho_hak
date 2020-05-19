using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class AddedIsPlacedPropToShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPlaced",
                table: "ShipGames",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlaced",
                table: "ShipGames");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "ConcurrencyStamp",
                value: "308cb2c6-044d-456c-a7f1-d0e5bb348da1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1f0741a-2e3e-4cea-bee9-db7ebfaefb68", "AQAAAAEAACcQAAAAEMxeiu9n4MFqzCjp8EkRg3KajzPNmkkSIcEOLleejJej39bhqdDJoCmjo9WUSvXoFg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6363adf-e217-4cc1-b117-c378218e6699", "AQAAAAEAACcQAAAAELlj8iGHMOHapQzSqR93QHitnpXNg5yZ89ga2F2RmI8cLc1NG1TlaVrjdoYvjwqi5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("31111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33d5d1a3-a655-4d33-bbf2-b4eb4393815c", "AQAAAAEAACcQAAAAEBrJmFs/V7QN/MvwI1PRe0KjmTTT7f64nQEr41VxXHHxNa1BNE61U3CkbqoHsBqsXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("41111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b19ebe0-cfd8-4c99-afb8-113e53d8a4f3", "AQAAAAEAACcQAAAAEM1etNMSCoebx40I2PUs56QA4Q56HSbOGqPxpqTeXM1M7ddc9GAxpOKMO636jblgiQ==" });
        }
    }
}
