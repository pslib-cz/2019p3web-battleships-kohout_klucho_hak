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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

    
        public DbSet<Game> Games { get; set; }
        public DbSet<NavyBattlePiece> NavyBattlePieces { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipGame> ShipGames { get; set; }
        public DbSet<ShipPiece> ShipPieces { get; set; }
        public DbSet<ShipUser> ShipUsers { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}
