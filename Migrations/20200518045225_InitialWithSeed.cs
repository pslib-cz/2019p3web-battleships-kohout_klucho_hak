using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleShips.Migrations
{
    public partial class InitialWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
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
                    PlayerName = table.Column<string>(maxLength: 15, nullable: true),
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
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    IsAllowed = table.Column<bool>(nullable: false)
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
                    RoleId = table.Column<Guid>(nullable: false),
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
                    UserId = table.Column<Guid>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                    OwnerId = table.Column<Guid>(nullable: false),
                    CurrentPlayerId = table.Column<Guid>(nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
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
                    ApplicationUserId = table.Column<Guid>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "5cf4f749-b354-4e05-bf9f-f82cdb045cf9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TotalPlayedGames", "TwoFactorEnabled", "UserName", "Wins" },
                values: new object[,]
                {
                    { new Guid("41111111-1111-1111-1111-111111111111"), 0, "2b36e7e5-38be-4b3f-a2b2-ca0b94911a84", "player3@pslib.cz", false, true, null, "PLAYER3@PSLIB.CZ", "PLAYER3@PSLIB.CZ", "AQAAAAEAACcQAAAAEETKvoesmzg6val6R2UgOPp66reMYzXM3QLVKYxfBAaiCKbHmeOj7mClBi0/EtbkoA==", null, false, "Player3", "", 12, false, "player3@pslib.cz", 3 },
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "b474e5e6-0e82-4184-b9ec-e6f55689b6cf", "admin@pslib.cz", false, true, null, "ADMIN@PSLIB.CZ", "ADMIN@PSLIB.CZ", "AQAAAAEAACcQAAAAEN2e36uDDe7BUJ4d/+sZ2aKB0O9zmer7YOHwYodbo8ZIaS9A6o4J6nv8PBvQ0HEpWQ==", null, false, "Admin", "", 0, false, "admin@pslib.cz", 0 },
                    { new Guid("21111111-1111-1111-1111-111111111111"), 0, "67500a40-10e9-4529-a8a7-23de18a23a26", "player1@pslib.cz", false, true, null, "PLAYER1@PSLIB.CZ", "PLAYER1@PSLIB.CZ", "AQAAAAEAACcQAAAAEIWIuvNm23E8gevIGAHkL69imQpnygJ5wVx3Uc+qhAMWXmOZhlCRM+PjEe3XRFLG8w==", null, false, "Player1", "", 10, false, "player1@pslib.cz", 3 },
                    { new Guid("31111111-1111-1111-1111-111111111111"), 0, "b6c3745c-3932-4a30-b8fa-53f4ca4fe682", "player2@pslib.cz", false, true, null, "PLAYER2@PSLIB.CZ", "PLAYER2@PSLIB.CZ", "AQAAAAEAACcQAAAAEKnH4EzJRxwILnRXrbsWMS9p1cFxjmyVg5DzPao11nbnl2WrNE9jvHzvLl9Yt/FapQ==", null, false, "Player2", "", 10, false, "player2@pslib.cz", 6 }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "IsAllowed", "Name" },
                values: new object[,]
                {
                    { 1, true, "Submarine" },
                    { 2, true, "Destroyer" },
                    { 3, true, "Cruiser" },
                    { 4, true, "Battleship" },
                    { 12, true, "Aircraft carrier II" },
                    { 6, true, "Landing base" },
                    { 7, true, "Hydro plane" },
                    { 8, true, "Cruiser II" },
                    { 9, true, "Heavy Cruiser" },
                    { 10, true, "Catamaran" },
                    { 11, true, "Light battleship" },
                    { 5, true, "Aircraft carrier" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CurrentPlayerId", "GameRound", "GameSize", "GameState", "MaxPlayers", "OwnerId", "UserRound" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("21111111-1111-1111-1111-111111111111"), 0, 2, 0, 2, new Guid("21111111-1111-1111-1111-111111111111"), 0 },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("21111111-1111-1111-1111-111111111111"), 0, 2, 2, 2, new Guid("21111111-1111-1111-1111-111111111111"), 0 }
                });

            migrationBuilder.InsertData(
                table: "ShipPieces",
                columns: new[] { "Id", "PieceState", "PosX", "PosY", "ShipId" },
                values: new object[,]
                {
                    { 146, 1, 2, 3, 9 },
                    { 147, 4, 2, 4, 9 },
                    { 148, 0, 3, 0, 9 },
                    { 149, 4, 3, 1, 9 },
                    { 150, 1, 3, 2, 9 },
                    { 151, 4, 3, 3, 9 },
                    { 152, 0, 3, 4, 9 },
                    { 153, 0, 4, 0, 9 },
                    { 154, 0, 4, 1, 9 },
                    { 155, 4, 4, 2, 9 },
                    { 156, 0, 4, 3, 9 },
                    { 157, 0, 4, 4, 9 },
                    { 158, 0, 0, 0, 10 },
                    { 159, 4, 0, 1, 10 },
                    { 160, 4, 0, 2, 10 },
                    { 161, 4, 0, 3, 10 },
                    { 162, 0, 0, 4, 10 },
                    { 163, 4, 1, 0, 10 },
                    { 164, 1, 1, 1, 10 },
                    { 165, 1, 1, 2, 10 },
                    { 1660, 1, 1, 3, 10 },
                    { 1670, 4, 1, 4, 10 },
                    { 1680, 0, 2, 0, 10 },
                    { 1690, 4, 2, 1, 10 },
                    { 1700, 1, 2, 2, 10 },
                    { 145, 1, 2, 2, 9 },
                    { 144, 1, 2, 1, 9 },
                    { 143, 4, 2, 0, 9 },
                    { 142, 0, 1, 4, 9 },
                    { 116, 0, 0, 3, 8 },
                    { 117, 0, 1, 0, 8 },
                    { 118, 4, 1, 1, 8 },
                    { 119, 1, 1, 2, 8 },
                    { 120, 4, 1, 3, 8 },
                    { 121, 4, 2, 0, 8 },
                    { 122, 1, 2, 1, 8 },
                    { 123, 1, 2, 2, 8 },
                    { 124, 4, 2, 3, 8 },
                    { 125, 0, 3, 0, 8 },
                    { 126, 4, 3, 1, 8 },
                    { 127, 1, 3, 2, 8 },
                    { 1710, 4, 2, 3, 10 },
                    { 128, 4, 3, 3, 8 },
                    { 130, 0, 4, 1, 8 },
                    { 131, 4, 4, 2, 8 },
                    { 132, 0, 4, 3, 8 },
                    { 133, 0, 0, 0, 9 },
                    { 134, 0, 0, 1, 9 },
                    { 135, 4, 0, 2, 9 },
                    { 136, 0, 0, 3, 9 },
                    { 137, 0, 0, 4, 9 },
                    { 138, 0, 1, 0, 9 },
                    { 139, 4, 1, 1, 9 },
                    { 140, 1, 1, 2, 9 },
                    { 141, 4, 1, 3, 9 },
                    { 129, 0, 4, 0, 8 },
                    { 115, 4, 0, 2, 8 },
                    { 1720, 0, 2, 4, 10 },
                    { 1740, 1, 3, 1, 10 },
                    { 194, 1, 1, 2, 12 },
                    { 195, 4, 1, 3, 12 },
                    { 196, 0, 2, 0, 12 },
                    { 197, 4, 2, 1, 12 },
                    { 198, 1, 2, 2, 12 },
                    { 199, 4, 2, 3, 12 },
                    { 200, 0, 2, 0, 12 },
                    { 201, 4, 2, 1, 12 },
                    { 202, 1, 2, 2, 12 },
                    { 203, 4, 2, 3, 12 },
                    { 204, 0, 3, 0, 12 },
                    { 205, 4, 3, 1, 12 },
                    { 206, 1, 3, 2, 12 },
                    { 207, 4, 3, 3, 12 },
                    { 208, 4, 4, 0, 12 },
                    { 209, 1, 4, 1, 12 },
                    { 210, 1, 4, 2, 12 },
                    { 211, 4, 4, 3, 12 },
                    { 212, 4, 5, 0, 12 },
                    { 213, 1, 5, 1, 12 },
                    { 214, 1, 5, 2, 12 },
                    { 215, 4, 5, 3, 12 },
                    { 216, 0, 6, 0, 12 },
                    { 217, 4, 6, 1, 12 },
                    { 218, 4, 6, 2, 12 },
                    { 193, 4, 1, 1, 12 },
                    { 192, 0, 1, 0, 12 },
                    { 191, 0, 0, 3, 12 },
                    { 190, 4, 0, 2, 12 },
                    { 1750, 1, 3, 2, 10 },
                    { 166, 1, 3, 3, 10 },
                    { 167, 4, 3, 4, 10 },
                    { 168, 0, 4, 0, 10 },
                    { 169, 4, 4, 1, 10 },
                    { 170, 4, 4, 2, 10 },
                    { 171, 4, 4, 3, 10 },
                    { 172, 0, 4, 4, 10 },
                    { 173, 0, 0, 0, 11 },
                    { 174, 4, 0, 1, 11 },
                    { 175, 4, 0, 2, 11 },
                    { 176, 0, 0, 3, 11 },
                    { 1730, 4, 3, 0, 10 },
                    { 177, 4, 1, 0, 11 },
                    { 179, 1, 1, 2, 11 },
                    { 180, 4, 1, 3, 11 },
                    { 181, 0, 2, 0, 11 },
                    { 182, 4, 2, 1, 11 },
                    { 183, 1, 2, 2, 11 },
                    { 184, 4, 2, 3, 11 },
                    { 185, 0, 3, 0, 11 },
                    { 186, 4, 3, 1, 11 },
                    { 187, 4, 3, 2, 11 },
                    { 1880, 0, 3, 3, 11 },
                    { 188, 0, 0, 0, 12 },
                    { 189, 0, 0, 1, 12 },
                    { 178, 1, 1, 1, 11 },
                    { 1, 1, 1, 1, 1 },
                    { 114, 0, 0, 1, 8 },
                    { 112, 0, 5, 3, 7 },
                    { 31, 4, 3, 0, 3 },
                    { 32, 1, 3, 1, 3 },
                    { 33, 4, 3, 2, 3 },
                    { 34, 0, 4, 0, 3 },
                    { 35, 4, 4, 1, 3 },
                    { 36, 0, 4, 2, 3 },
                    { 37, 0, 0, 0, 4 },
                    { 350, 4, 0, 1, 4 },
                    { 360, 0, 0, 2, 4 },
                    { 370, 4, 1, 0, 4 },
                    { 38, 1, 1, 1, 4 },
                    { 39, 4, 1, 2, 4 },
                    { 40, 4, 2, 0, 4 },
                    { 41, 1, 2, 1, 4 },
                    { 42, 4, 2, 2, 4 },
                    { 43, 4, 3, 0, 4 },
                    { 44, 1, 3, 1, 4 },
                    { 45, 4, 3, 2, 4 },
                    { 46, 4, 4, 0, 4 },
                    { 47, 1, 4, 1, 4 },
                    { 48, 4, 4, 2, 4 },
                    { 49, 0, 5, 0, 4 },
                    { 50, 4, 5, 1, 4 },
                    { 51, 0, 5, 2, 4 },
                    { 52, 0, 0, 0, 5 },
                    { 30, 4, 2, 2, 3 },
                    { 53, 4, 0, 1, 5 },
                    { 29, 1, 2, 1, 3 },
                    { 27, 4, 1, 2, 3 },
                    { 2, 4, 0, 1, 1 },
                    { 3, 4, 1, 0, 1 },
                    { 4, 4, 2, 1, 1 },
                    { 5, 4, 1, 2, 1 },
                    { 6, 0, 0, 0, 1 },
                    { 7, 0, 2, 0, 1 },
                    { 8, 0, 0, 2, 1 },
                    { 9, 0, 2, 2, 1 },
                    { 10, 0, 0, 0, 2 },
                    { 11, 4, 0, 1, 2 },
                    { 12, 0, 0, 2, 2 },
                    { 13, 4, 1, 0, 2 },
                    { 14, 1, 1, 1, 2 },
                    { 15, 4, 1, 2, 2 },
                    { 16, 4, 2, 0, 2 },
                    { 17, 1, 2, 1, 2 },
                    { 18, 4, 2, 2, 2 },
                    { 19, 0, 3, 0, 2 },
                    { 20, 4, 3, 1, 2 },
                    { 21, 0, 3, 2, 2 },
                    { 22, 0, 0, 0, 3 },
                    { 23, 4, 0, 1, 3 },
                    { 24, 0, 0, 2, 3 },
                    { 25, 4, 1, 0, 3 },
                    { 26, 1, 1, 1, 3 },
                    { 28, 4, 2, 0, 3 },
                    { 54, 0, 0, 2, 5 },
                    { 55, 4, 1, 0, 5 },
                    { 56, 1, 1, 1, 5 },
                    { 87, 1, 3, 2, 6 },
                    { 88, 4, 3, 3, 6 },
                    { 89, 0, 4, 0, 6 },
                    { 90, 4, 4, 1, 6 },
                    { 91, 4, 4, 2, 6 },
                    { 92, 0, 4, 3, 6 },
                    { 93, 0, 0, 0, 7 },
                    { 94, 0, 0, 1, 7 },
                    { 95, 4, 0, 2, 7 },
                    { 96, 0, 0, 3, 7 },
                    { 97, 0, 1, 0, 7 },
                    { 98, 4, 1, 1, 7 },
                    { 99, 1, 1, 2, 7 },
                    { 100, 4, 1, 3, 7 },
                    { 101, 4, 2, 0, 7 },
                    { 102, 1, 2, 1, 7 },
                    { 103, 4, 2, 2, 7 },
                    { 104, 0, 0, 3, 7 },
                    { 105, 0, 3, 0, 7 },
                    { 106, 4, 3, 1, 7 },
                    { 107, 1, 3, 2, 7 },
                    { 108, 4, 3, 3, 7 },
                    { 109, 0, 5, 0, 7 },
                    { 110, 0, 5, 1, 7 },
                    { 111, 4, 5, 2, 7 },
                    { 86, 1, 3, 1, 6 },
                    { 85, 4, 3, 0, 6 },
                    { 84, 4, 2, 3, 6 },
                    { 83, 1, 2, 2, 6 },
                    { 57, 4, 1, 2, 5 },
                    { 58, 4, 2, 0, 5 },
                    { 59, 1, 2, 1, 5 },
                    { 60, 4, 2, 2, 5 },
                    { 61, 4, 3, 0, 5 },
                    { 62, 1, 3, 1, 5 },
                    { 63, 4, 3, 2, 5 },
                    { 64, 4, 4, 0, 5 },
                    { 65, 1, 4, 1, 5 },
                    { 66, 4, 4, 2, 5 },
                    { 67, 4, 5, 0, 5 },
                    { 68, 1, 5, 1, 5 },
                    { 219, 0, 6, 3, 12 },
                    { 69, 4, 5, 2, 5 },
                    { 71, 4, 6, 1, 5 },
                    { 72, 0, 6, 2, 5 },
                    { 73, 0, 0, 0, 6 },
                    { 74, 4, 0, 1, 6 },
                    { 75, 4, 0, 2, 6 },
                    { 76, 0, 0, 3, 6 },
                    { 77, 4, 1, 0, 6 },
                    { 78, 1, 1, 1, 6 },
                    { 79, 1, 1, 2, 6 },
                    { 80, 4, 1, 3, 6 },
                    { 81, 4, 2, 0, 6 },
                    { 82, 1, 2, 1, 6 },
                    { 70, 0, 6, 0, 5 },
                    { 113, 0, 0, 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "ApplicationUserId", "GameId", "PlayerState" },
                values: new object[] { 1, new Guid("21111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111113"), 1 });

            migrationBuilder.InsertData(
                table: "UserGames",
                columns: new[] { "Id", "ApplicationUserId", "GameId", "PlayerState" },
                values: new object[] { 2, new Guid("31111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111113"), 1 });

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
