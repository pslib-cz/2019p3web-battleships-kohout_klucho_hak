using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string PlayerName { get; set; }

        public int Score { get; set; } 

        public int Wins { get; set; } 

        public int TotalPlayedGames { get; set; } 

       

    }
}
