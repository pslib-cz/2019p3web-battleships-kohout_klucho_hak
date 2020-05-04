using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(20, ErrorMessage = "You need to keep the name to max of 20 characters.")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for an Username")]
        [DisplayName("Username")]
        public string PlayerName { get; set; }

       

        public int Wins { get; set; } 

        public int TotalPlayedGames { get; set; }
        public int Score { get; set; }

    }
}
