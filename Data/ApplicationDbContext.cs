using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BattleShips.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 1, Name = "Submarine" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 2, Name = "Destroyer" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 3, Name = "Cruiser" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 4, Name = "Battleship" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 5, Name = "Aircraft carrier" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 6, Name = "Landing base" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 7, Name = "Hydro plane" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 8, Name = "Cruiser II" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 9, Name = "Heavy Cruiser" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 10, Name = "Catamaran" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 11, Name = "Light battleship" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 12, Name = "Aircraft carrier II" });

           

            ApplicationUser playerOne = new ApplicationUser
            {
                UserName = "player1@pslib.cz",
                PlayerName = "Player1",
                Email = "player1@pslib.cz",
                NormalizedEmail = "player1@pslib.cz".ToUpper(),
                NormalizedUserName = "player1@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                PhoneNumberConfirmed = false,
                 PasswordHash = "AQAAAAEAACcQAAAAEP6fMWCJXnEht0lxMRHtkrtDphMQdQHesFZ7F7CQz/AKx8HHipQO7Ojxmj+Fphf3qw==" //Lode123.
            };

            ApplicationUser playerTwo = new ApplicationUser
            {
                UserName = "player2@pslib.cz",
                PlayerName = "Player2",
                Email = "player2@pslib.cz",
                NormalizedEmail = "player2@pslib.cz".ToUpper(),
                NormalizedUserName = "player2@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                PhoneNumberConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEP6fMWCJXnEht0lxMRHtkrtDphMQdQHesFZ7F7CQz/AKx8HHipQO7Ojxmj+Fphf3qw==" //Lode123.
            };

            ApplicationUser playerThree = new ApplicationUser
            {
                UserName = "player3@pslib.cz",
                PlayerName = "Player3",
                Email = "player3@pslib.cz",
                NormalizedEmail = "player3@pslib.cz".ToUpper(),
                NormalizedUserName = "player3@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                PhoneNumberConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEP6fMWCJXnEht0lxMRHtkrtDphMQdQHesFZ7F7CQz/AKx8HHipQO7Ojxmj+Fphf3qw==" //Lode123.
            };

            //PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            //playerOne.PasswordHash = ph.HashPassword(playerOne, "Lode123.");
            //playerTwo.PasswordHash = ph.HashPassword(playerTwo, "Lode123.");
            //playerThree.PasswordHash = ph.HashPassword(playerThree, "Lode123.");

            modelBuilder.Entity<ApplicationUser>().HasData(
               playerOne
            ) ;
            modelBuilder.Entity<ApplicationUser>().HasData(
               playerTwo
            );
            modelBuilder.Entity<ApplicationUser>().HasData(
               playerThree
            );

            Game gameOne = new Game
            {
                Id = new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413c"),
                MaxPlayers = 2,
                GameSize = 2,
                GameRound = 0,
                OwnerId = playerOne.Id,
                CurrentPlayerId = playerOne.Id,
                GameState = GameState.Setup
            } ;

            Game gameTwo = new Game
            {
                Id = new Guid("80828d2b-e7e0-4316-aa6b-cea1d08f413e"),
                MaxPlayers = 2,
                GameSize = 2,
                GameRound = 0,
                OwnerId = playerOne.Id,
                CurrentPlayerId = playerOne.Id,
                GameState = GameState.Battle
            };

            modelBuilder.Entity<Game>().HasData(gameOne);
            modelBuilder.Entity<Game>().HasData(gameTwo);

            UserGame userGameOne = new UserGame           
            {
                Id = 1,
                ApplicationUserId = playerOne.Id,
                GameId = gameTwo.Id,
                PlayerState = PlayerState.Playing

            } ;
            UserGame userGameTwo = new UserGame
            {
                Id = 2,
                ApplicationUserId = playerTwo.Id,
                GameId = gameTwo.Id,
                PlayerState = PlayerState.Playing

            };

            modelBuilder.Entity<UserGame>().HasData(userGameOne);
            modelBuilder.Entity<UserGame>().HasData(userGameTwo);

            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece { 
                Id = 1, 
                PosX = 0,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = userGameOne.Id,
                Hidden = true
            });

            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 2,
                PosX = 1,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = userGameOne.Id,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 3,
                PosX = 0,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = userGameOne.Id,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 4,
                PosX = 1,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = userGameOne.Id,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 5,
                PosX = 0,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = userGameTwo.Id,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 6,
                PosX = 1,
                PosY = 0,
                TypeId = 1,
                PieceState = PieceState.Water,
                UserGameId = userGameTwo.Id,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 7,
                PosX = 0,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = userGameTwo.Id,
                Hidden = true
            });
            modelBuilder.Entity<NavyBattlePiece>().HasData(new NavyBattlePiece
            {
                Id = 8,
                PosX = 1,
                PosY = 1,
                TypeId = 1,
                PieceState = PieceState.Ship,
                UserGameId = userGameTwo.Id,
                Hidden = true
            });

            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 1,
                PosX = 1,
                PosY = 1,
                ShipId = 1,
                IsMargin = false
            }) ;
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 2,
                PosX = 0,
                PosY = 1,
                ShipId = 1,
                IsMargin = true
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 3,
                PosX = 1,
                PosY = 0,
                ShipId = 1,
                IsMargin = true
            });
            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 4,
                PosX = 2,
                PosY = 1,
                ShipId = 1,
                IsMargin = true
            });

            modelBuilder.Entity<ShipPiece>().HasData(new ShipPiece
            {
                Id = 5,
                PosX = 1,
                PosY = 2,
                ShipId = 1,
                IsMargin = true
            });
        }
    }
}
