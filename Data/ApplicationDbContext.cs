using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BattleShips.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Game> Game { get; set; }
        public DbSet<NavyBattlePiece> NavyBattlePiece { get; set; }
        public DbSet<Ship> Ship { get; set; }
        public DbSet<ShipGame> ShipGame { get; set; }
        public DbSet<ShipPiece> ShipPiece { get; set; }
        public DbSet<ShipUser> ShipUser { get; set; }
        public DbSet<UserGame> UserGame { get; set; }
    }
}
