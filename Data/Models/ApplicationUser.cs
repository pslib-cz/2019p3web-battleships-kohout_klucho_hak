using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Data
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(15, ErrorMessage = "Max length is 15 characters")]
        [MinLength(3, ErrorMessage = "Min length is 3 characters")]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        public int Wins { get; set; }

        public int TotalPlayedGames { get; set; }

        public ICollection<UserGame> UserGames { get; set; }

    }
}
