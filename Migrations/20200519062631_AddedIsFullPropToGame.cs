using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class AddedIsFullPropToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFull",
                table: "Games",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFull",
                table: "Games");

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
        }
    }
}
