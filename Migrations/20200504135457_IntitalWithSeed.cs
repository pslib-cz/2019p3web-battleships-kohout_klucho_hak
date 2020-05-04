﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class IntitalWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(maxLength: 20, nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    TotalPlayedGames = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaxPlayers = table.Column<int>(nullable: false),
                    GameSize = table.Column<int>(nullable: false),
                    GameRound = table.Column<int>(nullable: false),
                    UserRound = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: false),
                    CurrentPlayerId = table.Column<string>(nullable: true),
                    GameState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_CurrentPlayerId",
                        column: x => x.CurrentPlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipPieces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipId = table.Column<int>(nullable: false),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    PieceState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipPieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipPieces_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipId = table.Column<int>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipGames_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    GameId = table.Column<Guid>(nullable: false),
                    PlayerState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGames_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NavyBattlePieces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosX = table.Column<int>(nullable: false),
                    PosY = table.Column<int>(nullable: false),
                    UserGameId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false),
                    PieceState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavyBattlePieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavyBattlePieces_Ships_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NavyBattlePieces_UserGames_UserGameId",
                        column: x => x.UserGameId,
                        principalTable: "UserGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipId = table.Column<int>(nullable: false),
                    UserGameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipUsers_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipUsers_UserGames_UserGameId",
                        column: x => x.UserGameId,
                        principalTable: "UserGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TotalPlayedGames", "TwoFactorEnabled", "UserName", "Wins" },
                values: new object[,]
                {
                    { "3e42196d-9a77-4667-9f90-44d61b361159", 0, "f45805da-dcad-49c3-8268-0f5bc3b6c246", "player1@pslib.cz", false, true, null, "PLAYER1@PSLIB.CZ", "PLAYER1@PSLIB.CZ", "AQAAAAEAACcQAAAAEP6fMWCJXnEht0lxMRHtkrtDphMQdQHesFZ7F7CQz/AKx8HHipQO7Ojxmj+Fphf3qw==", null, false, "Player1", "b390e6f7-7850-4eb1-adcc-10fbe787c9fc", 0, false, "player1@pslib.cz", 0 },
                    { "e9f61305-8496-4089-a291-f44828b43c9c", 0, "62fcbc73-87f9-4b0d-b0d1-4d314a351b8a", "player2@pslib.cz", false, true, null, "PLAYER2@PSLIB.CZ", "PLAYER2@PSLIB.CZ", "AQAAAAEAACcQAAAAEP6fMWCJXnEht0lxMRHtkrtDphMQdQHesFZ7F7CQz/AKx8HHipQO7Ojxmj+Fphf3qw==", null, false, "Player2", "82080c62-7b10-4122-ab37-4cb1010d8900", 0, false, "player2@pslib.cz", 0 },
                    { "55c337ee-a687-49d9-ad2d-9cfbd49bdd7f", 0, "bb6959de-92d6-4e70-bd66-72ce4ab8ca78", "player3@pslib.cz", false, true, null, "PLAYER3@PSLIB.CZ", "PLAYER3@PSLIB.CZ", "AQAAAAEAACcQAAAAEP6fMWCJXnEht0lxMRHtkrtDphMQdQHesFZ7F7CQz/AKx8HHipQO7Ojxmj+Fphf3qw==", null, false, "Player3", "1b7e8f8a-cc64-45c4-ac8c-523fcb8b4307", 0, false, "player3@pslib.cz", 0 }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Submarine" },
                    { 2, "Destroyer" },
                    { 3, "Cruiser" },
                    { 4, "Battleship" },
                    { 5, "Aircraft carrier" },
                    { 6, "Landing base" },
                    { 7, "Hydro plane" },
                    { 8, "Cruiser II" },
                    { 9, "Heavy Cruiser" },
                    { 10, "Catamaran" },
                    { 11, "Light battleship" },
                    { 12, "Aircraft carrier II" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentPlayerId", "GameRound", "GameSize", "GameState", "MaxPlayers", "OwnerId", "UserRound" },
                values: new object[,]
                {
                    { new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413c"), "3e42196d-9a77-4667-9f90-44d61b361159", 0, 2, 0, 2, "3e42196d-9a77-4667-9f90-44d61b361159", 0 },
                    { new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413e"), "3e42196d-9a77-4667-9f90-44d61b361159", 0, 2, 2, 2, "3e42196d-9a77-4667-9f90-44d61b361159", 0 }
                });

            migrationBuilder.InsertData(
                table: "ShipPieces",
                columns: new[] { "Id", "PieceState", "PosX", "PosY", "ShipId" },
                values: new object[,]
                {
                    { 1, 3, 1, 1, 1 },
                    { 2, 4, 0, 1, 1 },
                    { 3, 4, 1, 0, 1 },
                    { 4, 4, 2, 1, 1 },
                    { 5, 4, 1, 2, 1 },
                    { 6, 2, 0, 0, 1 },
                    { 7, 2, 2, 0, 1 },
                    { 8, 2, 0, 2, 1 },
                    { 9, 2, 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "ApplicationUserId", "GameId", "PlayerState" },
                values: new object[] { 1, "3e42196d-9a77-4667-9f90-44d61b361159", new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413e"), 1 });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "ApplicationUserId", "GameId", "PlayerState" },
                values: new object[] { 2, "e9f61305-8496-4089-a291-f44828b43c9c", new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413e"), 1 });

            migrationBuilder.InsertData(
                table: "NavyBattlePieces",
                columns: new[] { "Id", "Hidden", "PieceState", "PosX", "PosY", "TypeId", "UserGameId" },
                values: new object[,]
                {
                    { 1, true, 1, 0, 0, 1, 1 },
                    { 2, true, 1, 1, 0, 1, 1 },
                    { 3, true, 0, 0, 1, 1, 1 },
                    { 4, true, 0, 1, 1, 1, 1 },
                    { 5, true, 0, 0, 0, 1, 2 },
                    { 6, true, 0, 1, 0, 1, 2 },
                    { 7, true, 1, 0, 1, 1, 2 },
                    { 8, true, 1, 1, 1, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CurrentPlayerId",
                table: "Games",
                column: "CurrentPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OwnerId",
                table: "Games",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_NavyBattlePieces_TypeId",
                table: "NavyBattlePieces",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NavyBattlePieces_UserGameId",
                table: "NavyBattlePieces",
                column: "UserGameId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_GameId",
                table: "ShipGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGames_ShipId",
                table: "ShipGames",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipPieces_ShipId",
                table: "ShipPieces",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipUsers_ShipId",
                table: "ShipUsers",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipUsers_UserGameId",
                table: "ShipUsers",
                column: "UserGameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_ApplicationUserId",
                table: "UserGames",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NavyBattlePieces");

            migrationBuilder.DropTable(
                name: "ShipGames");

            migrationBuilder.DropTable(
                name: "ShipPieces");

            migrationBuilder.DropTable(
                name: "ShipUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}