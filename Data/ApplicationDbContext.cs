using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BattleShips.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
 
        public DbSet<Game> Games { get; set; }
        public DbSet<NavyBattlePiece> NavyBattlePieces { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipGame> ShipGames { get; set; }
        public DbSet<ShipPiece> ShipPieces { get; set; }
        public DbSet<ShipUser> ShipUsers { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Ship Seed
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 1, Name = "Submarine", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 2, Name = "Destroyer", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 3, Name = "Cruiser", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 4, Name = "Battleship", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 5, Name = "Aircraft carrier", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 6, Name = "Landing base", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 7, Name = "Hydro plane", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 8, Name = "Cruiser II", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 9, Name = "Heavy Cruiser", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 10, Name = "Catamaran", IsAllowed = true });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 11, Name = "Light battleship", IsAllowed = true });
            #endregion



            #region Users, Roles, UserRoles Seed
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid> { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Admin", NormalizedName = "ADMIN" });
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                UserName = "admin@pslib.cz",
                PlayerName = "Admin",
                Email = "admin@pslib.cz",
                NormalizedEmail = "admin@pslib.cz".ToUpper(),
                NormalizedUserName = "admin@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                TotalPlayedGames = 0,
                Wins = 0,
                PhoneNumberConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123."),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> { RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111"), UserId = Guid.Parse("11111111-1111-1111-1111-111111111111") });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.Parse("21111111-1111-1111-1111-111111111111"),
                UserName = "player1@pslib.cz",
                PlayerName = "Player1",
                Email = "player1@pslib.cz",
                NormalizedEmail = "player1@pslib.cz".ToUpper(),
                NormalizedUserName = "player1@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                TotalPlayedGames = 10,
                Wins = 3,
                PhoneNumberConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Lode123."),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.Parse("31111111-1111-1111-1111-111111111111"),
                UserName = "player2@pslib.cz",
                PlayerName = "Player2",
                Email = "player2@pslib.cz",
                NormalizedEmail = "player2@pslib.cz".ToUpper(),
                NormalizedUserName = "player2@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                TotalPlayedGames = 10,
                Wins = 6,
                PhoneNumberConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Lode123."),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.Parse("41111111-1111-1111-1111-111111111111"),
                UserName = "player3@pslib.cz",
                PlayerName = "Player3",
                Email = "player3@pslib.cz",
                NormalizedEmail = "player3@pslib.cz".ToUpper(),
                NormalizedUserName = "player3@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                TotalPlayedGames = 12,
                Wins = 3,
                PhoneNumberConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Lode123."),
                SecurityStamp = string.Empty
            });

            #endregion

            #region Games Seed
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                MaxPlayers = 2,
                GameSize = 2,
                GameRound = 0,
                OwnerId = Guid.Parse("21111111-1111-1111-1111-111111111111"),
                CurrentPlayerId = Guid.Parse("21111111-1111-1111-1111-111111111111"),
                GameState = GameState.Setup
            });

            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                MaxPlayers = 2,
                GameSize = 2,
                GameRound = 0,
                OwnerId = Guid.Parse("21111111-1111-1111-1111-111111111111"),
                CurrentPlayerId = Guid.Parse("21111111-1111-1111-1111-111111111111"),
                GameState = GameState.Battle
            });

            #endregion

            #region UserGames Seed
            modelBuilder.Entity<UserGame>().HasData(new UserGame
            {
                Id = 1,
                ApplicationUserId = Guid.Parse("21111111-1111-1111-1111-111111111111"),
                GameId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                PlayerState = PlayerState.Playing

            });
            modelBuilder.Entity<UserGame>().HasData(new UserGame
            {
                Id = 2,
                ApplicationUserId = Guid.Parse("31111111-1111-1111-1111-111111111111"),
                GameId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                PlayerState = PlayerState.Playing

            });
            #endregion

            #region NavyBattlePieces Seed for one game
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 1,
                PosX = 0,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = 1,
                Hidden = true
            });

            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 2,
                PosX = 1,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = 1,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 3,
                PosX = 0,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = 1,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 4,
                PosX = 1,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = 1,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 5,
                PosX = 0,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = 2,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 6,
                PosX = 1,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = 2,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 7,
                PosX = 0,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = 2,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 8,
                PosX = 1,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = 2,
                Hidden = true
            });
            #endregion

            //Ships battleSipPieces
            //
            //Each BattleShip is divided into x-columns for better navigation
            #region ShipPieces Seed
            #region Submarine
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1,
                PosX = 1,
                PosY = 1,
                ShipId = 1,
                PieceState = PieceState.Ship
            }) ;
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 2,
                PosX = 0,
                PosY = 1,
                ShipId = 1,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 3,
                PosX = 1,
                PosY = 0,
                ShipId = 1,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 4,
                PosX = 2,
                PosY = 1,
                ShipId = 1,
                PieceState = PieceState.Margin
            });

            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 5,
                PosX = 1,
                PosY = 2,
                ShipId = 1,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 6,
                PosX = 0,
                PosY = 0,
                ShipId = 1,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 7,
                PosX = 2,
                PosY = 0,
                ShipId = 1,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 8,
                PosX = 0,
                PosY = 2,
                ShipId = 1,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 9,
                PosX = 2,
                PosY = 2,
                ShipId = 1,
                PieceState = PieceState.Water
            });
            #endregion

            #region Destroyer

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 10,
                PosX = 0,
                PosY = 0,
                ShipId = 2,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 11,
                PosX = 0,
                PosY = 1,
                ShipId = 2,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 12,
                PosX = 0,
                PosY = 2,
                ShipId = 2,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 13,
                PosX = 1,
                PosY = 0,
                ShipId = 2,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 14,
                PosX = 1,
                PosY = 1,
                ShipId = 2,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 15,
                PosX = 1,
                PosY = 2,
                ShipId = 2,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 16,
                PosX = 2,
                PosY = 0,
                ShipId = 2,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 17,
                PosX = 2,
                PosY = 1,
                ShipId = 2,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 18,
                PosX = 2,
                PosY = 2,
                ShipId = 2,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 19,
                PosX = 3,
                PosY = 0,
                ShipId = 2,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 20,
                PosX = 3,
                PosY = 1,
                ShipId = 2,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 21,
                PosX = 3,
                PosY = 2,
                ShipId = 2,
                PieceState = PieceState.Water
            });
            #endregion

            #region Cruiser

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 22,
                PosX = 0,
                PosY = 0,
                ShipId = 3,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 23,
                PosX = 0,
                PosY = 1,
                ShipId = 3,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 24,
                PosX = 0,
                PosY = 2,
                ShipId = 3,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 25,
                PosX = 1,
                PosY = 0,
                ShipId = 3,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 26,
                PosX = 1,
                PosY = 1,
                ShipId = 3,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 27,
                PosX = 1,
                PosY = 2,
                ShipId = 3,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 28,
                PosX = 2,
                PosY = 0,
                ShipId = 3,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 29,
                PosX = 2,
                PosY = 1,
                ShipId = 3,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 30,
                PosX = 2,
                PosY = 2,
                ShipId = 3,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 31,
                PosX = 3,
                PosY = 0,
                ShipId = 3,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 32,
                PosX = 3,
                PosY = 1,
                ShipId = 3,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 33,
                PosX = 3,
                PosY = 2,
                ShipId = 3,
                PieceState = PieceState.Margin
            });

            //x = 4
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 34,
                PosX = 4,
                PosY = 0,
                ShipId = 3,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 35,
                PosX = 4,
                PosY = 1,
                ShipId = 3,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 36,
                PosX = 4,
                PosY = 2,
                ShipId = 3,
                PieceState = PieceState.Water
            });

            #endregion

            #region BattleShip

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 37,
                PosX = 0,
                PosY = 0,
                ShipId = 4,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 350,
                PosX = 0,
                PosY = 1,
                ShipId = 4,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 360,
                PosX = 0,
                PosY = 2,
                ShipId = 4,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 370,
                PosX = 1,
                PosY = 0,
                ShipId = 4,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 38,
                PosX = 1,
                PosY = 1,
                ShipId = 4,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 39,
                PosX = 1,
                PosY = 2,
                ShipId = 4,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 40,
                PosX = 2,
                PosY = 0,
                ShipId = 4,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 41,
                PosX = 2,
                PosY = 1,
                ShipId = 4,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 42,
                PosX = 2,
                PosY = 2,
                ShipId = 4,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 43,
                PosX = 3,
                PosY = 0,
                ShipId = 4,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 44,
                PosX = 3,
                PosY = 1,
                ShipId = 4,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 45,
                PosX = 3,
                PosY = 2,
                ShipId = 4,
                PieceState = PieceState.Margin
            });

            //x = 4
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 46,
                PosX = 4,
                PosY = 0,
                ShipId = 4,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 47,
                PosX = 4,
                PosY = 1,
                ShipId = 4,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 48,
                PosX = 4,
                PosY = 2,
                ShipId = 4,
                PieceState = PieceState.Margin
            });

            //x = 5
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 49,
                PosX = 5,
                PosY = 0,
                ShipId = 4,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 50,
                PosX = 5,
                PosY = 1,
                ShipId = 4,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 51,
                PosX = 5,
                PosY = 2,
                ShipId = 4,
                PieceState = PieceState.Water
            });
            #endregion

            #region Aircraft Carrier

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 52,
                PosX = 0,
                PosY = 0,
                ShipId = 5,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 53,
                PosX = 0,
                PosY = 1,
                ShipId = 5,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 54,
                PosX = 0,
                PosY = 2,
                ShipId = 5,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 55,
                PosX = 1,
                PosY = 0,
                ShipId = 5,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 56,
                PosX = 1,
                PosY = 1,
                ShipId = 5,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 57,
                PosX = 1,
                PosY = 2,
                ShipId = 5,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 58,
                PosX = 2,
                PosY = 0,
                ShipId = 5,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 59,
                PosX = 2,
                PosY = 1,
                ShipId = 5,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 60,
                PosX = 2,
                PosY = 2,
                ShipId = 5,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 61,
                PosX = 3,
                PosY = 0,
                ShipId = 5,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 62,
                PosX = 3,
                PosY = 1,
                ShipId = 5,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 63,
                PosX = 3,
                PosY = 2,
                ShipId = 5,
                PieceState = PieceState.Margin
            });

            //x = 4
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 64,
                PosX = 4,
                PosY = 0,
                ShipId = 5,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 65,
                PosX = 4,
                PosY = 1,
                ShipId = 5,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 66,
                PosX = 4,
                PosY = 2,
                ShipId = 5,
                PieceState = PieceState.Margin
            });

            //x = 5
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 67,
                PosX = 5,
                PosY = 0,
                ShipId = 5,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 68,
                PosX = 5,
                PosY = 1,
                ShipId = 5,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 69,
                PosX = 5,
                PosY = 2,
                ShipId = 5,
                PieceState = PieceState.Margin
            });

            //x = 6
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 70,
                PosX = 6,
                PosY = 0,
                ShipId = 5,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 71,
                PosX = 6,
                PosY = 1,
                ShipId = 5,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 72,
                PosX = 6,
                PosY = 2,
                ShipId = 5,
                PieceState = PieceState.Water
            });
            #endregion

            #region Landing base

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 73,
                PosX = 0,
                PosY = 0,
                ShipId = 6,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 74,
                PosX = 0,
                PosY = 1,
                ShipId = 6,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 75,
                PosX = 0,
                PosY = 2,
                ShipId = 6,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 76,
                PosX = 0,
                PosY = 3,
                ShipId = 6,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 77,
                PosX = 1,
                PosY = 0,
                ShipId = 6,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 78,
                PosX = 1,
                PosY = 1,
                ShipId = 6,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 79,
                PosX = 1,
                PosY = 2,
                ShipId = 6,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 80,
                PosX = 1,
                PosY = 3,
                ShipId = 6,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 81,
                PosX = 2,
                PosY = 0,
                ShipId = 6,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 82,
                PosX = 2,
                PosY = 1,
                ShipId = 6,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 83,
                PosX = 2,
                PosY = 2,
                ShipId = 6,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 84,
                PosX = 2,
                PosY = 3,
                ShipId = 6,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 85,
                PosX = 3,
                PosY = 0,
                ShipId = 6,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 86,
                PosX = 3,
                PosY = 1,
                ShipId = 6,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 87,
                PosX = 3,
                PosY = 2,
                ShipId = 6,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 88,
                PosX = 3,
                PosY = 3,
                ShipId = 6,
                PieceState = PieceState.Margin
            });

            //x = 4
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 89,
                PosX = 4,
                PosY = 0,
                ShipId = 6,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 90,
                PosX = 4,
                PosY = 1,
                ShipId = 6,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 91,
                PosX = 4,
                PosY = 2,
                ShipId = 6,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 92,
                PosX = 4,
                PosY = 3,
                ShipId = 6,
                PieceState = PieceState.Water
            });
            #endregion

            #region Hydro plane

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 93,
                PosX = 0,
                PosY = 0,
                ShipId = 7,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 94,
                PosX = 0,
                PosY = 1,
                ShipId = 7,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 95,
                PosX = 0,
                PosY = 2,
                ShipId = 7,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 96,
                PosX = 0,
                PosY = 3,
                ShipId = 7,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 97,
                PosX = 1,
                PosY = 0,
                ShipId = 7,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 98,
                PosX = 1,
                PosY = 1,
                ShipId = 7,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 99,
                PosX = 1,
                PosY = 2,
                ShipId = 7,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 100,
                PosX = 1,
                PosY = 3,
                ShipId = 7,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 101,
                PosX = 2,
                PosY = 0,
                ShipId = 7,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 102,
                PosX = 2,
                PosY = 1,
                ShipId = 7,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 103,
                PosX = 2,
                PosY = 2,
                ShipId = 7,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 104,
                PosX = 2,
                PosY = 3,
                ShipId = 7,
                PieceState = PieceState.Water
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 105,
                PosX = 3,
                PosY = 0,
                ShipId = 7,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 106,
                PosX = 3,
                PosY = 1,
                ShipId = 7,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 107,
                PosX = 3,
                PosY = 2,
                ShipId = 7,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 108,
                PosX = 3,
                PosY = 3,
                ShipId = 7,
                PieceState = PieceState.Margin
            });

            //x = 5
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 109,
                PosX = 5,
                PosY = 0,
                ShipId = 7,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 110,
                PosX = 5,
                PosY = 1,
                ShipId = 7,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 111,
                PosX = 5,
                PosY = 2,
                ShipId = 7,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 112,
                PosX = 5,
                PosY = 3,
                ShipId = 7,
                PieceState = PieceState.Water
            });
            #endregion

            #region Cruiser II

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 113,
                PosX = 0,
                PosY = 0,
                ShipId = 8,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 114,
                PosX = 0,
                PosY = 1,
                ShipId = 8,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 115,
                PosX = 0,
                PosY = 2,
                ShipId = 8,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 116,
                PosX = 0,
                PosY = 3,
                ShipId = 8,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 117,
                PosX = 1,
                PosY = 0,
                ShipId = 8,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 118,
                PosX = 1,
                PosY = 1,
                ShipId = 8,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 119,
                PosX = 1,
                PosY = 2,
                ShipId = 8,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 120,
                PosX = 1,
                PosY = 3,
                ShipId = 8,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 121,
                PosX = 2,
                PosY = 0,
                ShipId = 8,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 122,
                PosX = 2,
                PosY = 1,
                ShipId = 8,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 123,
                PosX = 2,
                PosY = 2,
                ShipId = 8,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 124,
                PosX = 2,
                PosY = 3,
                ShipId = 8,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 125,
                PosX = 3,
                PosY = 0,
                ShipId = 8,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 126,
                PosX = 3,
                PosY = 1,
                ShipId = 8,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 127,
                PosX = 3,
                PosY = 2,
                ShipId = 8,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 128,
                PosX = 3,
                PosY = 3,
                ShipId = 8,
                PieceState = PieceState.Margin
            });

            //x = 4
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 129,
                PosX = 4,
                PosY = 0,
                ShipId = 8,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 130,
                PosX = 4,
                PosY = 1,
                ShipId = 8,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 131,
                PosX = 4,
                PosY = 2,
                ShipId = 8,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 132,
                PosX = 4,
                PosY = 3,
                ShipId = 8,
                PieceState = PieceState.Water
            });
            #endregion

            #region Heavy Cruiser

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 133,
                PosX = 0,
                PosY = 0,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 134,
                PosX = 0,
                PosY = 1,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 135,
                PosX = 0,
                PosY = 2,
                ShipId = 9,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 136,
                PosX = 0,
                PosY = 3,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 137,
                PosX = 0,
                PosY = 4,
                ShipId = 9,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 138,
                PosX = 1,
                PosY = 0,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 139,
                PosX = 1,
                PosY = 1,
                ShipId = 9,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 140,
                PosX = 1,
                PosY = 2,
                ShipId = 9,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 141,
                PosX = 1,
                PosY = 3,
                ShipId = 9,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 142,
                PosX = 1,
                PosY = 4,
                ShipId = 9,
                PieceState = PieceState.Water
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 143,
                PosX = 2,
                PosY = 0,
                ShipId = 9,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 144,
                PosX = 2,
                PosY = 1,
                ShipId = 9,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 145,
                PosX = 2,
                PosY = 2,
                ShipId = 9,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 146,
                PosX = 2,
                PosY = 3,
                ShipId = 9,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 147,
                PosX = 2,
                PosY = 4,
                ShipId = 9,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 148,
                PosX = 3,
                PosY = 0,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 149,
                PosX = 3,
                PosY = 1,
                ShipId = 9,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 150,
                PosX = 3,
                PosY = 2,
                ShipId = 9,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 151,
                PosX = 3,
                PosY = 3,
                ShipId = 9,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 152,
                PosX = 3,
                PosY = 4,
                ShipId = 9,
                PieceState = PieceState.Water
            });

            //x = 4
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 153,
                PosX = 4,
                PosY = 0,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 154,
                PosX = 4,
                PosY = 1,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 155,
                PosX = 4,
                PosY = 2,
                ShipId = 9,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 156,
                PosX = 4,
                PosY = 3,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 157,
                PosX = 4,
                PosY = 4,
                ShipId = 9,
                PieceState = PieceState.Water
            });
            #endregion

            #region Catamaran

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 158,
                PosX = 0,
                PosY = 0,
                ShipId = 10,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 159,
                PosX = 0,
                PosY = 1,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 160,
                PosX = 0,
                PosY = 2,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 161,
                PosX = 0,
                PosY = 3,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 162,
                PosX = 0,
                PosY = 4,
                ShipId = 10,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 163,
                PosX = 1,
                PosY = 0,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 164,
                PosX = 1,
                PosY = 1,
                ShipId = 10,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 165,
                PosX = 1,
                PosY = 2,
                ShipId = 10,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1660,
                PosX = 1,
                PosY = 3,
                ShipId = 10,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1670,
                PosX = 1,
                PosY = 4,
                ShipId = 10,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1680,
                PosX = 2,
                PosY = 0,
                ShipId = 10,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1690,
                PosX = 2,
                PosY = 1,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1700,
                PosX = 2,
                PosY = 2,
                ShipId = 10,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1710,
                PosX = 2,
                PosY = 3,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1720,
                PosX = 2,
                PosY = 4,
                ShipId = 10,
                PieceState = PieceState.Water
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1730,
                PosX = 3,
                PosY = 0,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1740,
                PosX = 3,
                PosY = 1,
                ShipId = 10,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1750,
                PosX = 3,
                PosY = 2,
                ShipId = 10,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 166,
                PosX = 3,
                PosY = 3,
                ShipId = 10,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 167,
                PosX = 3,
                PosY = 4,
                ShipId = 10,
                PieceState = PieceState.Margin
            });

            //x = 4
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 168,
                PosX = 4,
                PosY = 0,
                ShipId = 10,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 169,
                PosX = 4,
                PosY = 1,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 170,
                PosX = 4,
                PosY = 2,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 171,
                PosX = 4,
                PosY = 3,
                ShipId = 10,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 172,
                PosX = 4,
                PosY = 4,
                ShipId = 10,
                PieceState = PieceState.Water
            });
            #endregion

            #region Light BattleShip

            //x = 0
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 173,
                PosX = 0,
                PosY = 0,
                ShipId = 11,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 174,
                PosX = 0,
                PosY = 1,
                ShipId = 11,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 175,
                PosX = 0,
                PosY = 2,
                ShipId = 11,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 176,
                PosX = 0,
                PosY = 3,
                ShipId = 11,
                PieceState = PieceState.Water
            });

            //x = 1
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 177,
                PosX = 1,
                PosY = 0,
                ShipId = 11,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 178,
                PosX = 1,
                PosY = 1,
                ShipId = 11,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 179,
                PosX = 1,
                PosY = 2,
                ShipId = 11,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 180,
                PosX = 1,
                PosY = 3,
                ShipId = 11,
                PieceState = PieceState.Margin
            });

            //x = 2
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 181,
                PosX = 2,
                PosY = 0,
                ShipId = 11,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 182,
                PosX = 2,
                PosY = 1,
                ShipId = 11,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 183,
                PosX = 2,
                PosY = 2,
                ShipId = 11,
                PieceState = PieceState.Ship
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 184,
                PosX = 2,
                PosY = 3,
                ShipId = 11,
                PieceState = PieceState.Margin
            });

            //x = 3
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 185,
                PosX = 3,
                PosY = 0,
                ShipId = 11,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 186,
                PosX = 3,
                PosY = 1,
                ShipId = 11,
                PieceState = PieceState.Water
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 187,
                PosX = 3,
                PosY = 2,
                ShipId = 11,
                PieceState = PieceState.Margin
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1880,
                PosX = 3,
                PosY = 3,
                ShipId = 11,
                PieceState = PieceState.Water
            });
            #endregion
            #endregion
        }
    }
}
