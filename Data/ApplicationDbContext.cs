using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BattleShips.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 1, Name = "Ponorka" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 2, Name = "Torpédoborec" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 3, Name = "Křižník" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 4, Name = "Bitevní loď" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 5, Name = "Letadlová loď" });

            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 6, Name = "Přistávací základna" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 7, Name = "Hydroplán" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 8, Name = "Křižník II" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 9, Name = "Těžký křižník" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 10, Name = "Katamaran" });

            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 11, Name = "Lehká bitevní loď" });
            modelBuilder.Entity<Ship>().HasData(new Ship { Id = 12, Name = "Letadlová loď II" });



        }


    }
}
